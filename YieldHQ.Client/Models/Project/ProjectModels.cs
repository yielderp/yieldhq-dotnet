namespace YieldHQ.Client.Models.Project;

/// <summary>Represents a project.</summary>
public class Project
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string? Description { get; set; }
    public bool Active { get; set; } = true;
    public int Sequence { get; set; }
    public int? PartnerId { get; set; }
    public int? CompanyId { get; set; }
    public int? UserId { get; set; }
    public int Color { get; set; }
    public DateTime? DateStart { get; set; }
    public DateTime? Date { get; set; }
    public string PrivacyVisibility { get; set; } = "portal";
    public bool AllowMilestones { get; set; }
    public bool IsFavorite { get; set; }
    public int TaskCount { get; set; }
    public double AllocatedHours { get; set; }
    public double EffectiveHours { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents a task within a project.</summary>
public class ProjectTask
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string? Description { get; set; }
    public bool Active { get; set; } = true;
    public string Priority { get; set; } = "0";
    public int Sequence { get; set; }
    public int? ProjectId { get; set; }
    public int? StageId { get; set; }
    public string State { get; set; } = "01_in_progress";
    public bool IsClosed { get; set; }
    public int? PartnerId { get; set; }
    public DateTime? DateDeadline { get; set; }
    public double AllocatedHours { get; set; }
    public double EffectiveHours { get; set; }
    public double RemainingHours { get; set; }
    public int? ParentId { get; set; }
    public int? MilestoneId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents a project milestone.</summary>
public class ProjectMilestone
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int ProjectId { get; set; }
    public DateTime? Deadline { get; set; }
    public bool IsReached { get; set; }
    public DateTime? ReachedDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents a task stage (kanban column).</summary>
public class TaskStage
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Sequence { get; set; }
    public bool Active { get; set; } = true;
    public bool Fold { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents a project tag.</summary>
public class ProjectTag
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Color { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}
