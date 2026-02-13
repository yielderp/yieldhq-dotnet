using YieldHQ.Client.Models;
using YieldHQ.Client.Models.Partners;

namespace YieldHQ.Client.Resources;

/// <summary>Provides access to the Partners API.</summary>
public class PartnersResource : ResourceBase
{
    internal PartnersResource(HttpClient http) : base(http) { }

    /// <summary>List partners with optional pagination and filtering.</summary>
    public Task<PagedResult<Partner>> ListAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<Partner>("/api/v1/partners", query, ct);

    /// <summary>List all partners, auto-paginating through all pages.</summary>
    public IAsyncEnumerable<Partner> ListAllAsync(CancellationToken ct = default) =>
        ListAllAsync<Partner>("/api/v1/partners", ct: ct);

    /// <summary>List only customers.</summary>
    public Task<PagedResult<Partner>> ListCustomersAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<Partner>("/api/v1/partners", (query ?? new QueryParams()).Filter("filter", "customers"), ct);

    /// <summary>List only suppliers.</summary>
    public Task<PagedResult<Partner>> ListSuppliersAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<Partner>("/api/v1/partners", (query ?? new QueryParams()).Filter("filter", "suppliers"), ct);

    /// <summary>Get a single partner by ID.</summary>
    public Task<Partner> GetAsync(int id, CancellationToken ct = default) =>
        GetAsync<Partner>($"/api/v1/partners/{id}", ct);

    /// <summary>Create a new partner.</summary>
    public Task<int> CreateAsync(Partner partner, CancellationToken ct = default) =>
        CreateAsync<int>("/api/v1/partners", partner, ct);

    /// <summary>Update an existing partner.</summary>
    public Task UpdateAsync(int id, Partner partner, CancellationToken ct = default) =>
        UpdateAsync($"/api/v1/partners/{id}", partner, ct);

    /// <summary>Delete a partner.</summary>
    public Task DeleteAsync(int id, CancellationToken ct = default) =>
        DeleteAsync($"/api/v1/partners/{id}", ct);
}
