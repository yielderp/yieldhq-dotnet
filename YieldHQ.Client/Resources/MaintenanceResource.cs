using YieldHQ.Client.Models;
using YieldHQ.Client.Models.Maintenance;

namespace YieldHQ.Client.Resources;

/// <summary>Provides access to the Maintenance API.</summary>
public class MaintenanceResource : ResourceBase
{
    internal MaintenanceResource(HttpClient http) : base(http) { }

    // Requests
    /// <summary>List maintenance requests.</summary>
    public Task<PagedResult<MaintenanceRequest>> ListRequestsAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<MaintenanceRequest>("/api/v1/maintenance/requests", query, ct);

    /// <summary>Get a single maintenance request by ID.</summary>
    public Task<MaintenanceRequest> GetRequestAsync(int id, CancellationToken ct = default) =>
        GetAsync<MaintenanceRequest>($"/api/v1/maintenance/requests/{id}", ct);

    /// <summary>Create a new maintenance request.</summary>
    public Task<int> CreateRequestAsync(MaintenanceRequest request, CancellationToken ct = default) =>
        CreateAsync<int>("/api/v1/maintenance/requests", request, ct);

    /// <summary>Update a maintenance request.</summary>
    public Task UpdateRequestAsync(int id, MaintenanceRequest request, CancellationToken ct = default) =>
        UpdateAsync($"/api/v1/maintenance/requests/{id}", request, ct);

    /// <summary>Close a maintenance request.</summary>
    public Task CloseRequestAsync(int id, CancellationToken ct = default) =>
        ActionAsync($"/api/v1/maintenance/requests/{id}/close", ct: ct);

    // Equipment
    /// <summary>List equipment.</summary>
    public Task<PagedResult<Equipment>> ListEquipmentAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<Equipment>("/api/v1/maintenance/equipment", query, ct);

    /// <summary>Get a single equipment item by ID.</summary>
    public Task<Equipment> GetEquipmentAsync(int id, CancellationToken ct = default) =>
        GetAsync<Equipment>($"/api/v1/maintenance/equipment/{id}", ct);

    /// <summary>Create a new equipment item.</summary>
    public Task<int> CreateEquipmentAsync(Equipment equipment, CancellationToken ct = default) =>
        CreateAsync<int>("/api/v1/maintenance/equipment", equipment, ct);

    /// <summary>Update an equipment item.</summary>
    public Task UpdateEquipmentAsync(int id, Equipment equipment, CancellationToken ct = default) =>
        UpdateAsync($"/api/v1/maintenance/equipment/{id}", equipment, ct);

    // Categories
    /// <summary>List equipment categories.</summary>
    public Task<PagedResult<EquipmentCategory>> ListCategoriesAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<EquipmentCategory>("/api/v1/maintenance/categories", query, ct);

    /// <summary>Create a new equipment category.</summary>
    public Task<int> CreateCategoryAsync(EquipmentCategory category, CancellationToken ct = default) =>
        CreateAsync<int>("/api/v1/maintenance/categories", category, ct);

    // Teams
    /// <summary>List maintenance teams.</summary>
    public Task<PagedResult<Team>> ListTeamsAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<Team>("/api/v1/maintenance/teams", query, ct);

    /// <summary>Create a new maintenance team.</summary>
    public Task<int> CreateTeamAsync(Team team, CancellationToken ct = default) =>
        CreateAsync<int>("/api/v1/maintenance/teams", team, ct);

    // Stages
    /// <summary>List maintenance stages.</summary>
    public Task<PagedResult<Stage>> ListStagesAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<Stage>("/api/v1/maintenance/stages", query, ct);
}
