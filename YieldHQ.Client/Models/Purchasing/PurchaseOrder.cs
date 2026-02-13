namespace YieldHQ.Client.Models.Purchasing;

/// <summary>Represents a purchase order.</summary>
public class PurchaseOrder
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int PartnerId { get; set; }
    public int? CompanyId { get; set; }
    public string State { get; set; } = "draft";
    public DateTime DateOrder { get; set; }
    public DateTime? DateApprove { get; set; }
    public DateTime? DatePlanned { get; set; }
    public int? CurrencyId { get; set; }
    public int? UserId { get; set; }
    public string? Origin { get; set; }
    public string? Notes { get; set; }
    public double AmountUntaxed { get; set; }
    public double AmountTax { get; set; }
    public double AmountTotal { get; set; }
    public string? InvoiceStatus { get; set; }
    public string? ReceiptStatus { get; set; }
    public string? PartnerRef { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents a line item on a purchase order.</summary>
public class PurchaseOrderLine
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int Sequence { get; set; }
    public int? ProductId { get; set; }
    public string? Name { get; set; }
    public double ProductQty { get; set; }
    public int? ProductUom { get; set; }
    public double PriceUnit { get; set; }
    public double Discount { get; set; }
    public double PriceSubtotal { get; set; }
    public double PriceTotal { get; set; }
    public DateTime? DatePlanned { get; set; }
    public double QtyReceived { get; set; }
    public double QtyInvoiced { get; set; }
    public string? State { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}
