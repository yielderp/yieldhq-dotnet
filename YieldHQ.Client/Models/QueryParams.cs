namespace YieldHQ.Client.Models;

/// <summary>
/// Fluent builder for API query parameters (pagination, sorting, searching, filtering).
/// </summary>
public class QueryParams
{
    private int? _page;
    private int? _pageSize;
    private string? _sort;
    private string? _search;
    private readonly Dictionary<string, string> _filters = new();

    /// <summary>Set the page number (1-based).</summary>
    public QueryParams Page(int page) { _page = page; return this; }

    /// <summary>Set the number of items per page (max 100).</summary>
    public QueryParams PageSize(int size) { _pageSize = size; return this; }

    /// <summary>Sort by a field. Pass <paramref name="descending"/> = true for descending order.</summary>
    public QueryParams Sort(string field, bool descending = false) { _sort = descending ? $"-{field}" : field; return this; }

    /// <summary>Full-text search term.</summary>
    public QueryParams Search(string term) { _search = term; return this; }

    /// <summary>Add an arbitrary filter parameter.</summary>
    public QueryParams Filter(string key, string value) { _filters[key] = value; return this; }

    /// <summary>Build the query string (including the leading '?').</summary>
    public string ToQueryString()
    {
        var parts = new List<string>();
        if (_page.HasValue) parts.Add($"page={_page.Value}");
        if (_pageSize.HasValue) parts.Add($"pageSize={_pageSize.Value}");
        if (_sort != null) parts.Add($"sort={Uri.EscapeDataString(_sort)}");
        if (_search != null) parts.Add($"search={Uri.EscapeDataString(_search)}");
        foreach (var (key, value) in _filters)
            parts.Add($"{Uri.EscapeDataString(key)}={Uri.EscapeDataString(value)}");
        return parts.Count > 0 ? "?" + string.Join("&", parts) : "";
    }
}
