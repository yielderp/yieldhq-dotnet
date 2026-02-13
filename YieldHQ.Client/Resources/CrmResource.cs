using YieldHQ.Client.Models;
using YieldHQ.Client.Models.Crm;

namespace YieldHQ.Client.Resources;

/// <summary>Provides access to the CRM API (leads and teams).</summary>
public class CrmResource : ResourceBase
{
    internal CrmResource(HttpClient http) : base(http) { }

    /// <summary>List leads with optional type filter.</summary>
    public Task<PagedResult<Lead>> ListLeadsAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<Lead>("/api/v1/crm/leads", query, ct);

    /// <summary>List all leads, auto-paginating.</summary>
    public IAsyncEnumerable<Lead> ListAllLeadsAsync(CancellationToken ct = default) =>
        ListAllAsync<Lead>("/api/v1/crm/leads", ct: ct);

    /// <summary>Get a single lead by ID.</summary>
    public Task<Lead> GetLeadAsync(int id, CancellationToken ct = default) =>
        GetAsync<Lead>($"/api/v1/crm/leads/{id}", ct);

    /// <summary>Create a new lead.</summary>
    public Task<int> CreateLeadAsync(Lead lead, CancellationToken ct = default) =>
        CreateAsync<int>("/api/v1/crm/leads", lead, ct);

    /// <summary>Update an existing lead.</summary>
    public Task UpdateLeadAsync(int id, Lead lead, CancellationToken ct = default) =>
        UpdateAsync($"/api/v1/crm/leads/{id}", lead, ct);

    /// <summary>Delete a lead.</summary>
    public Task DeleteLeadAsync(int id, CancellationToken ct = default) =>
        DeleteAsync($"/api/v1/crm/leads/{id}", ct);

    /// <summary>Move a lead to a specific pipeline stage.</summary>
    public Task MoveToStageAsync(int id, int stageId, CancellationToken ct = default) =>
        ActionAsync($"/api/v1/crm/leads/{id}/stage", new MoveToStageRequest { StageId = stageId }, ct);

    /// <summary>List CRM teams.</summary>
    public Task<PagedResult<CrmTeam>> ListTeamsAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<CrmTeam>("/api/v1/crm/teams", query, ct);
}
