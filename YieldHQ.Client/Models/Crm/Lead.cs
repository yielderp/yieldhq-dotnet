namespace YieldHQ.Client.Models.Crm;

/// <summary>Represents a CRM lead or opportunity.</summary>
public class Lead
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Type { get; set; } = "lead";
    public int? PartnerId { get; set; }
    public int? UserId { get; set; }
    public int? TeamId { get; set; }
    public int? StageId { get; set; }
    public string Priority { get; set; } = "0";
    public double ExpectedRevenue { get; set; }
    public double Probability { get; set; }
    public string? EmailFrom { get; set; }
    public string? Phone { get; set; }
    public string? ContactName { get; set; }
    public string? PartnerName { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? Description { get; set; }
    public DateTime? DateDeadline { get; set; }
    public DateTime? DateOpen { get; set; }
    public DateTime? DateClosed { get; set; }
    public bool Active { get; set; } = true;
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents a CRM sales team.</summary>
public class CrmTeam
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Sequence { get; set; }
    public bool Active { get; set; } = true;
    public int? CompanyId { get; set; }
    public int? UserId { get; set; }
    public bool UseLeads { get; set; }
    public bool UseOpportunities { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Request body for moving a lead to a new stage.</summary>
public class MoveToStageRequest
{
    public int StageId { get; set; }
}
