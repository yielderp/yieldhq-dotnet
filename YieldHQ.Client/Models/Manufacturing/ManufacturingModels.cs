namespace YieldHQ.Client.Models.Manufacturing;

/// <summary>Represents a bill of materials.</summary>
public class BillOfMaterials
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public bool Active { get; set; } = true;
    public string Type { get; set; } = "normal";
    public int ProductTmplId { get; set; }
    public int? ProductId { get; set; }
    public double ProductQty { get; set; } = 1;
    public int? ProductUomId { get; set; }
    public int Sequence { get; set; }
    public int? CompanyId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents a line within a bill of materials.</summary>
public class BomLine
{
    public int Id { get; set; }
    public int BomId { get; set; }
    public int ProductId { get; set; }
    public double ProductQty { get; set; }
    public int? ProductUomId { get; set; }
    public int Sequence { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents a manufacturing production order.</summary>
public class ProductionOrder
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Priority { get; set; } = "0";
    public string? Origin { get; set; }
    public int ProductId { get; set; }
    public double ProductQty { get; set; }
    public int? ProductUomId { get; set; }
    public double QtyProduced { get; set; }
    public int? BomId { get; set; }
    public string State { get; set; } = "draft";
    public DateTime? DateStart { get; set; }
    public DateTime? DateFinished { get; set; }
    public DateTime? DateDeadline { get; set; }
    public int? UserId { get; set; }
    public int? CompanyId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents a work center.</summary>
public class WorkCenter
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string? Code { get; set; }
    public bool Active { get; set; } = true;
    public int Sequence { get; set; }
    public double DefaultCapacity { get; set; } = 1;
    public double TimeEfficiency { get; set; } = 100;
    public double CostsHour { get; set; }
    public string? Note { get; set; }
    public int? CompanyId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents a work order within a production order.</summary>
public class WorkOrder
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Sequence { get; set; }
    public int WorkcenterId { get; set; }
    public int ProductionId { get; set; }
    public int ProductId { get; set; }
    public double QtyProduction { get; set; }
    public double QtyProduced { get; set; }
    public double QtyRemaining { get; set; }
    public string State { get; set; } = "pending";
    public DateTime? DateStart { get; set; }
    public DateTime? DateFinished { get; set; }
    public double Duration { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents an unbuild order.</summary>
public class Unbuild
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int ProductId { get; set; }
    public double ProductQty { get; set; }
    public int? ProductUomId { get; set; }
    public int? BomId { get; set; }
    public int? MoId { get; set; }
    public string State { get; set; } = "draft";
    public int? LocationId { get; set; }
    public int? LocationDestId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}
