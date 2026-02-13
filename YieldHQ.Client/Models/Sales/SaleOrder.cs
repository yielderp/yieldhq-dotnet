namespace YieldHQ.Client.Models.Sales;

/// <summary>Represents a sale order.</summary>
public class SaleOrder
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int PartnerId { get; set; }
    public int? CompanyId { get; set; }
    public string State { get; set; } = "draft";
    public DateTime DateOrder { get; set; }
    public DateTime? ValidityDate { get; set; }
    public int? UserId { get; set; }
    public int? TeamId { get; set; }
    public int? CurrencyId { get; set; }
    public int? PricelistId { get; set; }
    public int? PaymentTermId { get; set; }
    public string? Note { get; set; }
    public double AmountUntaxed { get; set; }
    public double AmountTax { get; set; }
    public double AmountTotal { get; set; }
    public string? InvoiceStatus { get; set; }
    public string? ClientOrderRef { get; set; }
    public string? Origin { get; set; }
    public int? WarehouseId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents a line item on a sale order.</summary>
public class SaleOrderLine
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int Sequence { get; set; }
    public int? ProductId { get; set; }
    public string? Name { get; set; }
    public double ProductUomQty { get; set; }
    public int? ProductUom { get; set; }
    public double PriceUnit { get; set; }
    public double Discount { get; set; }
    public double PriceSubtotal { get; set; }
    public double PriceTax { get; set; }
    public double PriceTotal { get; set; }
    public double QtyDelivered { get; set; }
    public double QtyInvoiced { get; set; }
    public string? State { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}
