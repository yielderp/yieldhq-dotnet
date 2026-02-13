namespace YieldHQ.Client.Models.Products;

/// <summary>Represents a product template.</summary>
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Sequence { get; set; }
    public string? Description { get; set; }
    public string? DescriptionSale { get; set; }
    public string? DescriptionPurchase { get; set; }
    public string Type { get; set; } = "consu";
    public int CategId { get; set; }
    public int? CurrencyId { get; set; }
    public double ListPrice { get; set; }
    public double StandardPrice { get; set; }
    public double? Volume { get; set; }
    public double? Weight { get; set; }
    public bool SaleOk { get; set; } = true;
    public bool PurchaseOk { get; set; } = true;
    public int? UomId { get; set; }
    public int? CompanyId { get; set; }
    public bool Active { get; set; } = true;
    public string? Barcode { get; set; }
    public string? DefaultCode { get; set; }
    public bool IsStorable { get; set; }
    public string Tracking { get; set; } = "none";
    public string? InvoicePolicy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents a product category.</summary>
public class ProductCategory
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string? CompleteName { get; set; }
    public int? ParentId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}
