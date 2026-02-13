using System.Net;

namespace YieldHQ.Client.Exceptions;

/// <summary>
/// Base exception for all YieldHQ API errors.
/// </summary>
public class YieldException : Exception
{
    /// <summary>The HTTP status code returned by the API.</summary>
    public HttpStatusCode StatusCode { get; }

    /// <summary>The raw response body, if available.</summary>
    public string? ResponseBody { get; }

    /// <summary>Initializes a new <see cref="YieldException"/>.</summary>
    public YieldException(string message, HttpStatusCode statusCode, string? responseBody = null)
        : base(message)
    {
        StatusCode = statusCode;
        ResponseBody = responseBody;
    }
}

/// <summary>Thrown when the API returns 401 Unauthorized.</summary>
public class YieldAuthException : YieldException
{
    /// <summary>Initializes a new <see cref="YieldAuthException"/>.</summary>
    public YieldAuthException(string message, string? responseBody = null)
        : base(message, HttpStatusCode.Unauthorized, responseBody) { }
}

/// <summary>Thrown when the API returns 403 Forbidden.</summary>
public class YieldForbiddenException : YieldException
{
    /// <summary>Initializes a new <see cref="YieldForbiddenException"/>.</summary>
    public YieldForbiddenException(string message, string? responseBody = null)
        : base(message, HttpStatusCode.Forbidden, responseBody) { }
}

/// <summary>Thrown when the API returns 404 Not Found.</summary>
public class YieldNotFoundException : YieldException
{
    /// <summary>Initializes a new <see cref="YieldNotFoundException"/>.</summary>
    public YieldNotFoundException(string message, string? responseBody = null)
        : base(message, HttpStatusCode.NotFound, responseBody) { }
}

/// <summary>Thrown when the API returns 400 Bad Request or 422 Unprocessable Entity.</summary>
public class YieldValidationException : YieldException
{
    /// <summary>Field-level validation errors.</summary>
    public Dictionary<string, string[]> Errors { get; }

    /// <summary>Initializes a new <see cref="YieldValidationException"/>.</summary>
    public YieldValidationException(string message, HttpStatusCode statusCode, Dictionary<string, string[]>? errors = null, string? responseBody = null)
        : base(message, statusCode, responseBody)
    {
        Errors = errors ?? [];
    }
}

/// <summary>Thrown when the API returns 429 Too Many Requests.</summary>
public class YieldRateLimitException : YieldException
{
    /// <summary>Suggested wait time before retrying, parsed from the Retry-After header.</summary>
    public TimeSpan? RetryAfter { get; }

    /// <summary>Initializes a new <see cref="YieldRateLimitException"/>.</summary>
    public YieldRateLimitException(string message, TimeSpan? retryAfter = null, string? responseBody = null)
        : base(message, (HttpStatusCode)429, responseBody)
    {
        RetryAfter = retryAfter;
    }
}

/// <summary>Thrown when the API returns a 5xx server error.</summary>
public class YieldServerException : YieldException
{
    /// <summary>Initializes a new <see cref="YieldServerException"/>.</summary>
    public YieldServerException(string message, HttpStatusCode statusCode, string? responseBody = null)
        : base(message, statusCode, responseBody) { }
}
