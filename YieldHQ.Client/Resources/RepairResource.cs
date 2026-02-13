using YieldHQ.Client.Models;
using YieldHQ.Client.Models.Repair;

namespace YieldHQ.Client.Resources;

/// <summary>Provides access to the Repair API.</summary>
public class RepairResource : ResourceBase
{
    internal RepairResource(HttpClient http) : base(http) { }

    // Orders
    /// <summary>List repair orders.</summary>
    public Task<PagedResult<RepairOrder>> ListAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<RepairOrder>("/api/v1/repair/orders", query, ct);

    /// <summary>Get a single repair order by ID.</summary>
    public Task<RepairOrder> GetAsync(int id, CancellationToken ct = default) =>
        GetAsync<RepairOrder>($"/api/v1/repair/orders/{id}", ct);

    /// <summary>Create a new repair order.</summary>
    public Task<int> CreateAsync(RepairOrder order, CancellationToken ct = default) =>
        CreateAsync<int>("/api/v1/repair/orders", order, ct);

    /// <summary>Update a repair order.</summary>
    public Task UpdateAsync(int id, RepairOrder order, CancellationToken ct = default) =>
        UpdateAsync($"/api/v1/repair/orders/{id}", order, ct);

    // State transitions
    /// <summary>Confirm a repair order.</summary>
    public Task ConfirmAsync(int id, CancellationToken ct = default) =>
        ActionAsync($"/api/v1/repair/orders/{id}/confirm", ct: ct);

    /// <summary>Start repair work.</summary>
    public Task StartAsync(int id, CancellationToken ct = default) =>
        ActionAsync($"/api/v1/repair/orders/{id}/start", ct: ct);

    /// <summary>End repair work.</summary>
    public Task EndAsync(int id, CancellationToken ct = default) =>
        ActionAsync($"/api/v1/repair/orders/{id}/end", ct: ct);

    /// <summary>Mark repair as done.</summary>
    public Task DoneAsync(int id, CancellationToken ct = default) =>
        ActionAsync($"/api/v1/repair/orders/{id}/done", ct: ct);

    /// <summary>Cancel a repair order.</summary>
    public Task CancelAsync(int id, CancellationToken ct = default) =>
        ActionAsync($"/api/v1/repair/orders/{id}/cancel", ct: ct);

    // Lines (Parts)
    /// <summary>List parts lines for a repair order.</summary>
    public Task<PagedResult<RepairLine>> ListLinesAsync(int repairId, QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<RepairLine>($"/api/v1/repair/orders/{repairId}/lines", query, ct);

    /// <summary>Add a parts line to a repair order.</summary>
    public Task<int> AddLineAsync(int repairId, RepairLine line, CancellationToken ct = default) =>
        CreateAsync<int>($"/api/v1/repair/orders/{repairId}/lines", line, ct);

    /// <summary>Update a repair line.</summary>
    public Task UpdateLineAsync(int id, RepairLine line, CancellationToken ct = default) =>
        UpdateAsync($"/api/v1/repair/lines/{id}", line, ct);

    /// <summary>Delete a repair line.</summary>
    public Task DeleteLineAsync(int id, CancellationToken ct = default) =>
        DeleteAsync($"/api/v1/repair/lines/{id}", ct);

    // Fees
    /// <summary>List fees for a repair order.</summary>
    public Task<PagedResult<RepairFee>> ListFeesAsync(int repairId, QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<RepairFee>($"/api/v1/repair/orders/{repairId}/fees", query, ct);

    /// <summary>Add a fee to a repair order.</summary>
    public Task<int> AddFeeAsync(int repairId, RepairFee fee, CancellationToken ct = default) =>
        CreateAsync<int>($"/api/v1/repair/orders/{repairId}/fees", fee, ct);

    /// <summary>Update a repair fee.</summary>
    public Task UpdateFeeAsync(int id, RepairFee fee, CancellationToken ct = default) =>
        UpdateAsync($"/api/v1/repair/fees/{id}", fee, ct);

    /// <summary>Delete a repair fee.</summary>
    public Task DeleteFeeAsync(int id, CancellationToken ct = default) =>
        DeleteAsync($"/api/v1/repair/fees/{id}", ct);
}
