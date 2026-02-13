using System.Net;
using System.Net.Http.Headers;
using YieldHQ.Client.Exceptions;

namespace YieldHQ.Client.Http;

/// <summary>
/// Delegating handler that adds authentication, retry logic with exponential backoff,
/// and maps HTTP error responses to strongly-typed exceptions.
/// </summary>
public class YieldHttpHandler : DelegatingHandler
{
    private readonly YieldHQClientOptions _options;

    /// <summary>Initializes a new <see cref="YieldHttpHandler"/>.</summary>
    public YieldHttpHandler(YieldHQClientOptions options)
    {
        _options = options;
    }

    /// <inheritdoc/>
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _options.AccessToken);
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage? response = null;
        for (var attempt = 0; attempt <= _options.MaxRetries; attempt++)
        {
            if (attempt > 0)
            {
                var delay = GetDelay(attempt, response);
                await Task.Delay(delay, cancellationToken);

                // Clone the request for retry since the original may have been consumed
                request = await CloneRequestAsync(request);
            }

            response = await base.SendAsync(request, cancellationToken);

            if (response.IsSuccessStatusCode)
                return response;

            var isRetryable = (int)response.StatusCode == 429 || (int)response.StatusCode >= 500;
            if (!isRetryable || attempt == _options.MaxRetries)
                break;
        }

        await ThrowForStatusAsync(response!);
        return response!; // unreachable
    }

    private static TimeSpan GetDelay(int attempt, HttpResponseMessage? response)
    {
        if (response?.Headers.RetryAfter is not null)
        {
            if (response.Headers.RetryAfter.Delta.HasValue)
                return response.Headers.RetryAfter.Delta.Value;
            if (response.Headers.RetryAfter.Date.HasValue)
            {
                var wait = response.Headers.RetryAfter.Date.Value - DateTimeOffset.UtcNow;
                return wait > TimeSpan.Zero ? wait : TimeSpan.FromSeconds(1);
            }
        }

        return TimeSpan.FromSeconds(Math.Pow(2, attempt - 1)); // 1s, 2s, 4s
    }

    private static async Task<HttpRequestMessage> CloneRequestAsync(HttpRequestMessage original)
    {
        var clone = new HttpRequestMessage(original.Method, original.RequestUri);
        foreach (var header in original.Headers)
            clone.Headers.TryAddWithoutValidation(header.Key, header.Value);

        if (original.Content != null)
        {
            var content = await original.Content.ReadAsByteArrayAsync();
            clone.Content = new ByteArrayContent(content);
            foreach (var header in original.Content.Headers)
                clone.Content.Headers.TryAddWithoutValidation(header.Key, header.Value);
        }

        return clone;
    }

    private static async Task ThrowForStatusAsync(HttpResponseMessage response)
    {
        var body = await response.Content.ReadAsStringAsync();
        var status = response.StatusCode;

        throw status switch
        {
            HttpStatusCode.Unauthorized => new YieldAuthException("Authentication failed. Check your access token.", body),
            HttpStatusCode.Forbidden => new YieldForbiddenException("Access denied. Insufficient permissions.", body),
            HttpStatusCode.NotFound => new YieldNotFoundException("The requested resource was not found.", body),
            HttpStatusCode.BadRequest or HttpStatusCode.UnprocessableEntity => new YieldValidationException("Validation failed.", status, responseBody: body),
            (HttpStatusCode)429 => new YieldRateLimitException(
                "Rate limit exceeded.",
                response.Headers.RetryAfter?.Delta,
                body),
            _ when (int)status >= 500 => new YieldServerException($"Server error ({(int)status}).", status, body),
            _ => new YieldException($"Unexpected error ({(int)status}).", status, body),
        };
    }
}
