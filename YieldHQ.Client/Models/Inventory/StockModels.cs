namespace YieldHQ.Client.Models.Inventory;

/// <summary>Represents a stock transfer (picking).</summary>
public class StockTransfer
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string? Origin { get; set; }
    public int? PartnerId { get; set; }
    public string State { get; set; } = "draft";
    public int PickingTypeId { get; set; }
    public int LocationId { get; set; }
    public int LocationDestId { get; set; }
    public DateTime? ScheduledDate { get; set; }
    public DateTime? DateDone { get; set; }
    public int? CompanyId { get; set; }
    public int? UserId { get; set; }
    public string? Note { get; set; }
    public string Priority { get; set; } = "0";
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents a stock move within a transfer.</summary>
public class StockMove
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int ProductId { get; set; }
    public double ProductUomQty { get; set; }
    public int? ProductUom { get; set; }
    public double Quantity { get; set; }
    public int LocationId { get; set; }
    public int LocationDestId { get; set; }
    public int? PickingId { get; set; }
    public string State { get; set; } = "draft";
    public DateTime? Date { get; set; }
    public double PriceUnit { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents current stock levels at a location.</summary>
public class StockQuant
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int LocationId { get; set; }
    public int? LotId { get; set; }
    public int? CompanyId { get; set; }
    public double Quantity { get; set; }
    public double ReservedQuantity { get; set; }
    public double AvailableQuantity { get; set; }
    public DateTime? InDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents a warehouse.</summary>
public class Warehouse
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Code { get; set; } = "";
    public bool Active { get; set; } = true;
    public int? CompanyId { get; set; }
    public int? PartnerId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents a stock lot / serial number.</summary>
public class StockLot
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string? Ref { get; set; }
    public int ProductId { get; set; }
    public int? CompanyId { get; set; }
    public string? Note { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}
