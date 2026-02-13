namespace YieldHQ.Client.Models.Admin;

/// <summary>Represents an audit log entry.</summary>
public class AuditLog
{
    public long AuditId { get; set; }
    public string EventType { get; set; } = "";
    public string TableName { get; set; } = "";
    public string? EntityId { get; set; }
    public string? OldValues { get; set; }
    public string? NewValues { get; set; }
    public string? ChangedColumns { get; set; }
    public string? Username { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool Success { get; set; }
}

/// <summary>Represents a role for access control.</summary>
public class Role
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Code { get; set; } = "";
    public string? Description { get; set; }
    public bool IsAdmin { get; set; }
    public bool Active { get; set; } = true;
    public DateTime CreatedAt { get; set; }
}

/// <summary>Represents module-level access permissions for a role.</summary>
public class RoleAccess
{
    public int Id { get; set; }
    public int RoleId { get; set; }
    public string ModuleCode { get; set; } = "";
    public bool CanRead { get; set; } = true;
    public bool CanWrite { get; set; }
    public bool CanDelete { get; set; }
}

/// <summary>Request body for setting module access permissions.</summary>
public class ModuleAccessRequest
{
    public bool CanRead { get; set; } = true;
    public bool CanWrite { get; set; }
    public bool CanDelete { get; set; }
}
