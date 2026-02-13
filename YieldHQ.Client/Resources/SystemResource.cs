using YieldHQ.Client.Models;
using YieldHQ.Client.Models.System;

namespace YieldHQ.Client.Resources;

/// <summary>Provides access to the System API.</summary>
public class SystemResource : ResourceBase
{
    internal SystemResource(HttpClient http) : base(http) { }

    /// <summary>Check the health of the YieldHQ instance (does not require authentication).</summary>
    public Task<HealthStatus> HealthAsync(CancellationToken ct = default) =>
        GetAsync<HealthStatus>("/api/v1/system/health", ct);

    /// <summary>List installed modules.</summary>
    public Task<PagedResult<ModuleInfo>> ListModulesAsync(CancellationToken ct = default) =>
        ListAsync<ModuleInfo>("/api/v1/system/modules", ct: ct);
}
