namespace YieldHQ.Client.Models;

/// <summary>
/// Envelope for a single-item API response.
/// </summary>
/// <typeparam name="T">The type of the response data.</typeparam>
public class ApiResponse<T>
{
    /// <summary>Whether the request succeeded.</summary>
    public bool Success { get; set; }

    /// <summary>The response payload.</summary>
    public T? Data { get; set; }

    /// <summary>Optional message from the server.</summary>
    public string? Message { get; set; }
}

/// <summary>
/// Envelope for a paginated list API response.
/// </summary>
/// <typeparam name="T">The type of each item in the list.</typeparam>
public class ApiListResponse<T>
{
    /// <summary>Whether the request succeeded.</summary>
    public bool Success { get; set; }

    /// <summary>The list of items for the current page.</summary>
    public IEnumerable<T> Data { get; set; } = [];

    /// <summary>Pagination metadata.</summary>
    public ApiMeta Meta { get; set; } = new();
}

/// <summary>
/// Pagination metadata returned by list endpoints.
/// </summary>
public class ApiMeta
{
    /// <summary>Current page number (1-based).</summary>
    public int Page { get; set; }

    /// <summary>Number of items per page.</summary>
    public int PageSize { get; set; }

    /// <summary>Total number of items across all pages.</summary>
    public int Total { get; set; }
}

/// <summary>
/// Client-side representation of a paginated result set.
/// </summary>
/// <typeparam name="T">The type of each item.</typeparam>
public class PagedResult<T>
{
    /// <summary>The items on the current page.</summary>
    public List<T> Items { get; set; } = [];

    /// <summary>Current page number (1-based).</summary>
    public int Page { get; set; }

    /// <summary>Number of items per page.</summary>
    public int PageSize { get; set; }

    /// <summary>Total number of items across all pages.</summary>
    public int Total { get; set; }

    /// <summary>Total number of pages.</summary>
    public int TotalPages => PageSize > 0 ? (int)Math.Ceiling((double)Total / PageSize) : 0;

    /// <summary>Whether there is a subsequent page.</summary>
    public bool HasNextPage => Page < TotalPages;
}
