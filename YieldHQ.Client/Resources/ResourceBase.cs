using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using YieldHQ.Client.Models;

namespace YieldHQ.Client.Resources;

/// <summary>
/// Base class for all API resource classes, providing common HTTP helper methods.
/// </summary>
public abstract class ResourceBase
{
    private readonly HttpClient _http;

    /// <summary>JSON serializer options using camelCase naming.</summary>
    protected static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    /// <summary>Initializes the resource with an <see cref="HttpClient"/>.</summary>
    protected ResourceBase(HttpClient http)
    {
        _http = http;
    }

    /// <summary>GET a single resource by path.</summary>
    protected async Task<T> GetAsync<T>(string path, CancellationToken ct = default)
    {
        var response = await _http.GetFromJsonAsync<ApiResponse<T>>(path, JsonOptions, ct);
        return response!.Data!;
    }

    /// <summary>GET a paginated list of resources.</summary>
    protected async Task<PagedResult<T>> ListAsync<T>(string path, QueryParams? query = null, CancellationToken ct = default)
    {
        var url = path + (query?.ToQueryString() ?? "");
        var response = await _http.GetFromJsonAsync<ApiListResponse<T>>(url, JsonOptions, ct);
        var r = response!;
        return new PagedResult<T>
        {
            Items = r.Data.ToList(),
            Page = r.Meta.Page,
            PageSize = r.Meta.PageSize,
            Total = r.Meta.Total
        };
    }

    /// <summary>POST to create a new resource. Returns the created entity or its identifier.</summary>
    protected async Task<T> CreateAsync<T>(string path, object data, CancellationToken ct = default)
    {
        var response = await _http.PostAsJsonAsync(path, data, JsonOptions, ct);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ApiResponse<T>>(JsonOptions, ct);
        return result!.Data!;
    }

    /// <summary>PUT to update an existing resource.</summary>
    protected async Task UpdateAsync(string path, object data, CancellationToken ct = default)
    {
        var response = await _http.PutAsJsonAsync(path, data, JsonOptions, ct);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>DELETE a resource.</summary>
    protected async Task DeleteAsync(string path, CancellationToken ct = default)
    {
        var response = await _http.DeleteAsync(path, ct);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>POST an action on a resource (e.g. confirm, cancel).</summary>
    protected async Task ActionAsync(string path, object? data = null, CancellationToken ct = default)
    {
        var response = data != null
            ? await _http.PostAsJsonAsync(path, data, JsonOptions, ct)
            : await _http.PostAsync(path, null, ct);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>POST an action that returns a typed result.</summary>
    protected async Task<T> ActionAsync<T>(string path, object? data = null, CancellationToken ct = default)
    {
        var response = data != null
            ? await _http.PostAsJsonAsync(path, data, JsonOptions, ct)
            : await _http.PostAsync(path, null, ct);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ApiResponse<T>>(JsonOptions, ct);
        return result!.Data!;
    }

    /// <summary>
    /// Auto-paginate through all items, yielding each one via <see cref="IAsyncEnumerable{T}"/>.
    /// </summary>
    protected async IAsyncEnumerable<T> ListAllAsync<T>(string path, QueryParams? query = null, [EnumeratorCancellation] CancellationToken ct = default)
    {
        var q = query ?? new QueryParams();
        var page = 1;

        while (true)
        {
            var result = await ListAsync<T>(path, new QueryParams().Page(page).PageSize(100), ct);
            foreach (var item in result.Items)
                yield return item;

            if (!result.HasNextPage)
                break;

            page++;
        }
    }
}
