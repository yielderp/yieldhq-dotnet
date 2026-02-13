namespace YieldHQ.Client.Models.Partners;

/// <summary>Represents a business partner (customer, supplier, or contact).</summary>
public class Partner
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Ref { get; set; }
    public int? ParentId { get; set; }
    public string Type { get; set; } = "contact";
    public bool IsCompany { get; set; }
    public string? CompanyName { get; set; }
    public string? Function { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Mobile { get; set; }
    public string? Website { get; set; }
    public string? Street { get; set; }
    public string? Street2 { get; set; }
    public string? City { get; set; }
    public string? Zip { get; set; }
    public int? StateId { get; set; }
    public int? CountryId { get; set; }
    public string? CountryCode { get; set; }
    public string? Lang { get; set; }
    public string? Vat { get; set; }
    public string? Barcode { get; set; }
    public string? Comment { get; set; }
    public bool Active { get; set; } = true;
    public int CustomerRank { get; set; }
    public int SupplierRank { get; set; }
    public int? UserId { get; set; }
    public int? CurrencyId { get; set; }
    public decimal? Credit { get; set; }
    public decimal? Debit { get; set; }
    public double? CreditLimit { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}
