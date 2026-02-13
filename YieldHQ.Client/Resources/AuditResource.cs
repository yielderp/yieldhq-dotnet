using YieldHQ.Client.Models;
using YieldHQ.Client.Models.Admin;

namespace YieldHQ.Client.Resources;

/// <summary>Provides access to the Audit API (admin only).</summary>
public class AuditResource : ResourceBase
{
    internal AuditResource(HttpClient http) : base(http) { }

    /// <summary>List audit logs with optional filters.</summary>
    public Task<PagedResult<AuditLog>> ListLogsAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<AuditLog>("/api/v1/audit/logs", query, ct);

    /// <summary>Get a single audit log entry by ID.</summary>
    public Task<AuditLog> GetLogAsync(long id, CancellationToken ct = default) =>
        GetAsync<AuditLog>($"/api/v1/audit/logs/{id}", ct);

    /// <summary>Get the full audit history for a specific entity.</summary>
    public Task<PagedResult<AuditLog>> GetEntityHistoryAsync(string tableName, string entityId, QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<AuditLog>($"/api/v1/audit/entity/{tableName}/{entityId}", query, ct);
}
