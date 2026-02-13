using YieldHQ.Client.Models;
using YieldHQ.Client.Models.Manufacturing;

namespace YieldHQ.Client.Resources;

/// <summary>Provides access to the Manufacturing API.</summary>
public class ManufacturingResource : ResourceBase
{
    internal ManufacturingResource(HttpClient http) : base(http) { }

    // BOMs
    /// <summary>List bills of materials.</summary>
    public Task<PagedResult<BillOfMaterials>> ListBomsAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<BillOfMaterials>("/api/v1/manufacturing/boms", query, ct);

    /// <summary>Get a single BOM by ID.</summary>
    public Task<BillOfMaterials> GetBomAsync(int id, CancellationToken ct = default) =>
        GetAsync<BillOfMaterials>($"/api/v1/manufacturing/boms/{id}", ct);

    /// <summary>Create a new BOM.</summary>
    public Task<int> CreateBomAsync(BillOfMaterials bom, CancellationToken ct = default) =>
        CreateAsync<int>("/api/v1/manufacturing/boms", bom, ct);

    /// <summary>Update a BOM.</summary>
    public Task UpdateBomAsync(int id, BillOfMaterials bom, CancellationToken ct = default) =>
        UpdateAsync($"/api/v1/manufacturing/boms/{id}", bom, ct);

    /// <summary>List lines for a specific BOM.</summary>
    public Task<PagedResult<BomLine>> ListBomLinesAsync(int bomId, QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<BomLine>($"/api/v1/manufacturing/boms/{bomId}/lines", query, ct);

    // Productions
    /// <summary>List production orders.</summary>
    public Task<PagedResult<ProductionOrder>> ListProductionsAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<ProductionOrder>("/api/v1/manufacturing/productions", query, ct);

    /// <summary>Get a single production order by ID.</summary>
    public Task<ProductionOrder> GetProductionAsync(int id, CancellationToken ct = default) =>
        GetAsync<ProductionOrder>($"/api/v1/manufacturing/productions/{id}", ct);

    /// <summary>Create a new production order.</summary>
    public Task<int> CreateProductionAsync(ProductionOrder production, CancellationToken ct = default) =>
        CreateAsync<int>("/api/v1/manufacturing/productions", production, ct);

    /// <summary>Update a production order.</summary>
    public Task UpdateProductionAsync(int id, ProductionOrder production, CancellationToken ct = default) =>
        UpdateAsync($"/api/v1/manufacturing/productions/{id}", production, ct);

    /// <summary>Confirm a production order.</summary>
    public Task ConfirmProductionAsync(int id, CancellationToken ct = default) =>
        ActionAsync($"/api/v1/manufacturing/productions/{id}/confirm", ct: ct);

    /// <summary>Start a production order.</summary>
    public Task StartProductionAsync(int id, CancellationToken ct = default) =>
        ActionAsync($"/api/v1/manufacturing/productions/{id}/start", ct: ct);

    /// <summary>Mark a production order as done.</summary>
    public Task DoneProductionAsync(int id, CancellationToken ct = default) =>
        ActionAsync($"/api/v1/manufacturing/productions/{id}/done", ct: ct);

    /// <summary>Cancel a production order.</summary>
    public Task CancelProductionAsync(int id, CancellationToken ct = default) =>
        ActionAsync($"/api/v1/manufacturing/productions/{id}/cancel", ct: ct);

    /// <summary>List work orders for a production.</summary>
    public Task<PagedResult<WorkOrder>> ListProductionWorkordersAsync(int productionId, QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<WorkOrder>($"/api/v1/manufacturing/productions/{productionId}/workorders", query, ct);

    // Work Centers
    /// <summary>List work centers.</summary>
    public Task<PagedResult<WorkCenter>> ListWorkcentersAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<WorkCenter>("/api/v1/manufacturing/workcenters", query, ct);

    /// <summary>Get a single work center by ID.</summary>
    public Task<WorkCenter> GetWorkcenterAsync(int id, CancellationToken ct = default) =>
        GetAsync<WorkCenter>($"/api/v1/manufacturing/workcenters/{id}", ct);

    /// <summary>Create a new work center.</summary>
    public Task<int> CreateWorkcenterAsync(WorkCenter workcenter, CancellationToken ct = default) =>
        CreateAsync<int>("/api/v1/manufacturing/workcenters", workcenter, ct);

    // Work Orders
    /// <summary>List all work orders with optional state filter.</summary>
    public Task<PagedResult<WorkOrder>> ListWorkordersAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<WorkOrder>("/api/v1/manufacturing/workorders", query, ct);

    /// <summary>Start a work order.</summary>
    public Task StartWorkorderAsync(int id, CancellationToken ct = default) =>
        ActionAsync($"/api/v1/manufacturing/workorders/{id}/start", ct: ct);

    /// <summary>Mark a work order as done.</summary>
    public Task DoneWorkorderAsync(int id, CancellationToken ct = default) =>
        ActionAsync($"/api/v1/manufacturing/workorders/{id}/done", ct: ct);

    // Unbuilds
    /// <summary>List unbuild orders.</summary>
    public Task<PagedResult<Unbuild>> ListUnbuildsAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<Unbuild>("/api/v1/manufacturing/unbuilds", query, ct);
}
