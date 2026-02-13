namespace YieldHQ.Client.Models.Events;

/// <summary>Represents an event.</summary>
public class Event
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string? Note { get; set; }
    public string? Description { get; set; }
    public bool Active { get; set; } = true;
    public int? UserId { get; set; }
    public int? CompanyId { get; set; }
    public int? StageId { get; set; }
    public DateTime? DateBegin { get; set; }
    public DateTime? DateEnd { get; set; }
    public string? DateTz { get; set; }
    public int SeatsMax { get; set; }
    public bool SeatsLimited { get; set; }
    public int SeatsReserved { get; set; }
    public int SeatsUsed { get; set; }
    public int? AddressId { get; set; }
    public int? CountryId { get; set; }
    public bool EventRegistrationsOpen { get; set; } = true;
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents a registration for an event.</summary>
public class EventRegistration
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public int? EventTicketId { get; set; }
    public int? PartnerId { get; set; }
    public string Name { get; set; } = "";
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? CompanyName { get; set; }
    public string State { get; set; } = "draft";
    public bool Active { get; set; } = true;
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents an event ticket type.</summary>
public class EventTicket
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public string Name { get; set; } = "";
    public string? Description { get; set; }
    public int SeatsMax { get; set; }
    public int SeatsReserved { get; set; }
    public int SeatsAvailable { get; set; }
    public double Price { get; set; }
    public DateTime? StartSaleDatetime { get; set; }
    public DateTime? EndSaleDatetime { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents a booth at an event.</summary>
public class EventBooth
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public int? BoothCategoryId { get; set; }
    public int? PartnerId { get; set; }
    public string? ContactName { get; set; }
    public string? ContactEmail { get; set; }
    public string State { get; set; } = "available";
    public bool IsAvailable { get; set; } = true;
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents an event stage.</summary>
public class EventStage
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Sequence { get; set; }
    public bool Fold { get; set; }
    public bool PipeEnd { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}
