using YieldHQ.Client.Models;
using YieldHQ.Client.Models.Sales;

namespace YieldHQ.Client.Resources;

/// <summary>Provides access to the Sales Orders API.</summary>
public class SalesResource : ResourceBase
{
    internal SalesResource(HttpClient http) : base(http) { }

    /// <summary>List sale orders with optional state filter.</summary>
    public Task<PagedResult<SaleOrder>> ListAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<SaleOrder>("/api/v1/sales/orders", query, ct);

    /// <summary>List all sale orders, auto-paginating.</summary>
    public IAsyncEnumerable<SaleOrder> ListAllAsync(CancellationToken ct = default) =>
        ListAllAsync<SaleOrder>("/api/v1/sales/orders", ct: ct);

    /// <summary>Get a single sale order by ID.</summary>
    public Task<SaleOrder> GetAsync(int id, CancellationToken ct = default) =>
        GetAsync<SaleOrder>($"/api/v1/sales/orders/{id}", ct);

    /// <summary>Create a new sale order.</summary>
    public Task<int> CreateAsync(SaleOrder order, CancellationToken ct = default) =>
        CreateAsync<int>("/api/v1/sales/orders", order, ct);

    /// <summary>Update an existing sale order.</summary>
    public Task UpdateAsync(int id, SaleOrder order, CancellationToken ct = default) =>
        UpdateAsync($"/api/v1/sales/orders/{id}", order, ct);

    /// <summary>Confirm a sale order.</summary>
    public Task ConfirmAsync(int id, CancellationToken ct = default) =>
        ActionAsync($"/api/v1/sales/orders/{id}/confirm", ct: ct);

    /// <summary>Cancel a sale order.</summary>
    public Task CancelAsync(int id, CancellationToken ct = default) =>
        ActionAsync($"/api/v1/sales/orders/{id}/cancel", ct: ct);

    /// <summary>List order lines for a specific sale order.</summary>
    public Task<PagedResult<SaleOrderLine>> ListLinesAsync(int orderId, QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<SaleOrderLine>($"/api/v1/sales/orders/{orderId}/lines", query, ct);
}
