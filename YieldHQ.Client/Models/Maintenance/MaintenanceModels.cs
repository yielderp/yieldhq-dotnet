namespace YieldHQ.Client.Models.Maintenance;

/// <summary>Represents a maintenance request (work order).</summary>
public class MaintenanceRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int? CompanyId { get; set; }
    public string? Description { get; set; }
    public DateTime? RequestDate { get; set; }
    public int? CategoryId { get; set; }
    public int? EquipmentId { get; set; }
    public int? UserId { get; set; }
    public int? StageId { get; set; }
    public string Priority { get; set; } = "0";
    public DateTime? CloseDate { get; set; }
    public string MaintenanceType { get; set; } = "corrective";
    public DateTime? ScheduleDate { get; set; }
    public int? MaintenanceTeamId { get; set; }
    public double Duration { get; set; }
    public bool Done { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents a piece of equipment.</summary>
public class Equipment
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public bool Active { get; set; } = true;
    public int? CompanyId { get; set; }
    public int? CategoryId { get; set; }
    public int? TechnicianUserId { get; set; }
    public int? PartnerId { get; set; }
    public string? Location { get; set; }
    public string? Model { get; set; }
    public string? SerialNo { get; set; }
    public double Cost { get; set; }
    public string? Note { get; set; }
    public int? MaintenanceTeamId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents an equipment category.</summary>
public class EquipmentCategory
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int? CompanyId { get; set; }
    public int? TechnicianUserId { get; set; }
    public string? Note { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents a maintenance team.</summary>
public class Team
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public bool Active { get; set; } = true;
    public int? CompanyId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents a maintenance workflow stage.</summary>
public class Stage
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Sequence { get; set; }
    public bool Fold { get; set; }
    public bool Done { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}
