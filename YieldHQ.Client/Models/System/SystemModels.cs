namespace YieldHQ.Client.Models.System;

/// <summary>Represents the system health status.</summary>
public class HealthStatus
{
    public string Status { get; set; } = "";
    public DateTime Timestamp { get; set; }
}

/// <summary>Represents an installed module.</summary>
public class ModuleInfo
{
    public string ModuleCode { get; set; } = "";
    public string ModuleName { get; set; } = "";
    public string Version { get; set; } = "";
}
