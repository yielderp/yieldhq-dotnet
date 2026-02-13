using YieldHQ.Client.Models;
using YieldHQ.Client.Models.Inventory;

namespace YieldHQ.Client.Resources;

/// <summary>Provides access to the Inventory API.</summary>
public class InventoryResource : ResourceBase
{
    internal InventoryResource(HttpClient http) : base(http) { }

    /// <summary>List stock transfers with optional type and state filters.</summary>
    public Task<PagedResult<StockTransfer>> ListTransfersAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<StockTransfer>("/api/v1/inventory/transfers", query, ct);

    /// <summary>Get a single stock transfer by ID.</summary>
    public Task<StockTransfer> GetTransferAsync(int id, CancellationToken ct = default) =>
        GetAsync<StockTransfer>($"/api/v1/inventory/transfers/{id}", ct);

    /// <summary>List moves within a transfer.</summary>
    public Task<PagedResult<StockMove>> ListMovesAsync(int transferId, QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<StockMove>($"/api/v1/inventory/transfers/{transferId}/moves", query, ct);

    /// <summary>Confirm a stock transfer.</summary>
    public Task ConfirmTransferAsync(int id, CancellationToken ct = default) =>
        ActionAsync($"/api/v1/inventory/transfers/{id}/confirm", ct: ct);

    /// <summary>Validate a stock transfer.</summary>
    public Task ValidateTransferAsync(int id, CancellationToken ct = default) =>
        ActionAsync($"/api/v1/inventory/transfers/{id}/validate", ct: ct);

    /// <summary>Cancel a stock transfer.</summary>
    public Task CancelTransferAsync(int id, CancellationToken ct = default) =>
        ActionAsync($"/api/v1/inventory/transfers/{id}/cancel", ct: ct);

    /// <summary>List current stock levels, optionally filtered by product and/or location.</summary>
    public Task<PagedResult<StockQuant>> ListStockAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<StockQuant>("/api/v1/inventory/stock", query, ct);

    /// <summary>List warehouses.</summary>
    public Task<PagedResult<Warehouse>> ListWarehousesAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<Warehouse>("/api/v1/inventory/warehouses", query, ct);

    /// <summary>List stock lots, optionally filtered by product.</summary>
    public Task<PagedResult<StockLot>> ListLotsAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<StockLot>("/api/v1/inventory/lots", query, ct);
}
