namespace YieldHQ.Client.Models.Repair;

/// <summary>Represents a repair order.</summary>
public class RepairOrder
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int? CompanyId { get; set; }
    public string State { get; set; } = "draft";
    public string Priority { get; set; } = "0";
    public int? PartnerId { get; set; }
    public int? UserId { get; set; }
    public int ProductId { get; set; }
    public double ProductQty { get; set; }
    public int? ProductUom { get; set; }
    public int? LotId { get; set; }
    public int? LocationId { get; set; }
    public int? LocationDestId { get; set; }
    public string? InternalNotes { get; set; }
    public bool UnderWarranty { get; set; }
    public DateTime? ScheduleDate { get; set; }
    public double AmountUntaxed { get; set; }
    public double AmountTax { get; set; }
    public double AmountTotal { get; set; }
    public string? RepairRequest { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents a parts line on a repair order.</summary>
public class RepairLine
{
    public int Id { get; set; }
    public int RepairId { get; set; }
    public string Name { get; set; } = "";
    public int ProductId { get; set; }
    public double ProductUomQty { get; set; }
    public int? ProductUom { get; set; }
    public double PriceUnit { get; set; }
    public double PriceSubtotal { get; set; }
    public string Type { get; set; } = "add";
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents a fee (labor/service) on a repair order.</summary>
public class RepairFee
{
    public int Id { get; set; }
    public int RepairId { get; set; }
    public string Name { get; set; } = "";
    public int ProductId { get; set; }
    public double ProductUomQty { get; set; }
    public int? ProductUom { get; set; }
    public double PriceUnit { get; set; }
    public double PriceSubtotal { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}
