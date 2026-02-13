using YieldHQ.Client.Models;
using YieldHQ.Client.Models.Purchasing;

namespace YieldHQ.Client.Resources;

/// <summary>Provides access to the Purchase Orders API.</summary>
public class PurchasingResource : ResourceBase
{
    internal PurchasingResource(HttpClient http) : base(http) { }

    /// <summary>List purchase orders with optional state filter.</summary>
    public Task<PagedResult<PurchaseOrder>> ListAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<PurchaseOrder>("/api/v1/purchasing/orders", query, ct);

    /// <summary>List all purchase orders, auto-paginating.</summary>
    public IAsyncEnumerable<PurchaseOrder> ListAllAsync(CancellationToken ct = default) =>
        ListAllAsync<PurchaseOrder>("/api/v1/purchasing/orders", ct: ct);

    /// <summary>Get a single purchase order by ID.</summary>
    public Task<PurchaseOrder> GetAsync(int id, CancellationToken ct = default) =>
        GetAsync<PurchaseOrder>($"/api/v1/purchasing/orders/{id}", ct);

    /// <summary>Create a new purchase order.</summary>
    public Task<int> CreateAsync(PurchaseOrder order, CancellationToken ct = default) =>
        CreateAsync<int>("/api/v1/purchasing/orders", order, ct);

    /// <summary>Update an existing purchase order.</summary>
    public Task UpdateAsync(int id, PurchaseOrder order, CancellationToken ct = default) =>
        UpdateAsync($"/api/v1/purchasing/orders/{id}", order, ct);

    /// <summary>Confirm a purchase order.</summary>
    public Task ConfirmAsync(int id, CancellationToken ct = default) =>
        ActionAsync($"/api/v1/purchasing/orders/{id}/confirm", ct: ct);

    /// <summary>Cancel a purchase order.</summary>
    public Task CancelAsync(int id, CancellationToken ct = default) =>
        ActionAsync($"/api/v1/purchasing/orders/{id}/cancel", ct: ct);

    /// <summary>List order lines for a specific purchase order.</summary>
    public Task<PagedResult<PurchaseOrderLine>> ListLinesAsync(int orderId, QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<PurchaseOrderLine>($"/api/v1/purchasing/orders/{orderId}/lines", query, ct);
}
