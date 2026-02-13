using YieldHQ.Client.Models;
using YieldHQ.Client.Models.Admin;

namespace YieldHQ.Client.Resources;

/// <summary>Provides access to the Roles API (admin only).</summary>
public class RolesResource : ResourceBase
{
    internal RolesResource(HttpClient http) : base(http) { }

    /// <summary>List roles.</summary>
    public Task<PagedResult<Role>> ListAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<Role>("/api/v1/roles", query, ct);

    /// <summary>Get a single role by ID.</summary>
    public Task<Role> GetAsync(int id, CancellationToken ct = default) =>
        GetAsync<Role>($"/api/v1/roles/{id}", ct);

    /// <summary>Create a new role.</summary>
    public Task<int> CreateAsync(Role role, CancellationToken ct = default) =>
        CreateAsync<int>("/api/v1/roles", role, ct);

    /// <summary>Update a role.</summary>
    public Task UpdateAsync(int id, Role role, CancellationToken ct = default) =>
        UpdateAsync($"/api/v1/roles/{id}", role, ct);

    /// <summary>Delete a role.</summary>
    public Task DeleteAsync(int id, CancellationToken ct = default) =>
        DeleteAsync($"/api/v1/roles/{id}", ct);

    // User-role assignments
    /// <summary>List users assigned to a role.</summary>
    public Task<PagedResult<object>> ListRoleUsersAsync(int roleId, CancellationToken ct = default) =>
        ListAsync<object>($"/api/v1/roles/{roleId}/users", ct: ct);

    /// <summary>List roles assigned to a user.</summary>
    public Task<PagedResult<Role>> ListUserRolesAsync(int userId, CancellationToken ct = default) =>
        ListAsync<Role>($"/api/v1/users/{userId}/roles", ct: ct);

    /// <summary>Assign a role to a user.</summary>
    public Task AssignRoleAsync(int userId, int roleId, CancellationToken ct = default) =>
        ActionAsync($"/api/v1/users/{userId}/roles/{roleId}", ct: ct);

    /// <summary>Remove a role from a user.</summary>
    public Task RemoveRoleAsync(int userId, int roleId, CancellationToken ct = default) =>
        DeleteAsync($"/api/v1/users/{userId}/roles/{roleId}", ct);

    // Module access
    /// <summary>List module access permissions for a role.</summary>
    public Task<PagedResult<RoleAccess>> ListAccessAsync(int roleId, CancellationToken ct = default) =>
        ListAsync<RoleAccess>($"/api/v1/roles/{roleId}/access", ct: ct);

    /// <summary>Set module access permissions for a role.</summary>
    public Task SetAccessAsync(int roleId, string moduleCode, ModuleAccessRequest request, CancellationToken ct = default) =>
        UpdateAsync($"/api/v1/roles/{roleId}/access/{moduleCode}", request, ct);

    /// <summary>Remove module access for a role.</summary>
    public Task RemoveAccessAsync(int roleId, string moduleCode, CancellationToken ct = default) =>
        DeleteAsync($"/api/v1/roles/{roleId}/access/{moduleCode}", ct);
}
