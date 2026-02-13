namespace YieldHQ.Client.Models.Accounting;

/// <summary>Represents a chart of accounts entry.</summary>
public class Account
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Code { get; set; } = "";
    public string AccountType { get; set; } = "";
    public string? InternalGroup { get; set; }
    public int? CurrencyId { get; set; }
    public int? CompanyId { get; set; }
    public bool Reconcile { get; set; }
    public bool Deprecated { get; set; }
    public string? Note { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents an accounting move (invoice, bill, or journal entry).</summary>
public class AccountMove
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string? Ref { get; set; }
    public DateTime Date { get; set; }
    public string State { get; set; } = "draft";
    public string MoveType { get; set; } = "entry";
    public int JournalId { get; set; }
    public int? CompanyId { get; set; }
    public int? CurrencyId { get; set; }
    public int? PartnerId { get; set; }
    public DateTime? InvoiceDate { get; set; }
    public DateTime? InvoiceDateDue { get; set; }
    public int? InvoicePaymentTermId { get; set; }
    public string? PaymentReference { get; set; }
    public string? PaymentState { get; set; }
    public double AmountUntaxed { get; set; }
    public double AmountTax { get; set; }
    public double AmountTotal { get; set; }
    public double AmountResidual { get; set; }
    public string? Narration { get; set; }
    public string? InvoiceOrigin { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents a line item within an accounting move.</summary>
public class AccountMoveLine
{
    public int Id { get; set; }
    public int MoveId { get; set; }
    public int AccountId { get; set; }
    public string? Name { get; set; }
    public double Debit { get; set; }
    public double Credit { get; set; }
    public double Balance { get; set; }
    public int? PartnerId { get; set; }
    public int? ProductId { get; set; }
    public double Quantity { get; set; }
    public double PriceUnit { get; set; }
    public double PriceSubtotal { get; set; }
    public double PriceTotal { get; set; }
    public double Discount { get; set; }
    public DateTime Date { get; set; }
    public DateTime? DateMaturity { get; set; }
    public int Sequence { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents a payment.</summary>
public class Payment
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public DateTime Date { get; set; }
    public int JournalId { get; set; }
    public int? CompanyId { get; set; }
    public string State { get; set; } = "draft";
    public string PaymentType { get; set; } = "inbound";
    public string? PartnerType { get; set; }
    public double Amount { get; set; }
    public int? CurrencyId { get; set; }
    public int? PartnerId { get; set; }
    public string? Memo { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents a tax definition.</summary>
public class Tax
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string TypeTaxUse { get; set; } = "sale";
    public string AmountType { get; set; } = "percent";
    public bool Active { get; set; } = true;
    public int Sequence { get; set; }
    public double Amount { get; set; }
    public string? Description { get; set; }
    public bool PriceInclude { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents an accounting journal.</summary>
public class Journal
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Code { get; set; } = "";
    public string Type { get; set; } = "general";
    public bool Active { get; set; } = true;
    public int? DefaultAccountId { get; set; }
    public int? CompanyId { get; set; }
    public int Sequence { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents payment terms.</summary>
public class PaymentTerm
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public bool Active { get; set; } = true;
    public string? Note { get; set; }
    public int Sequence { get; set; }
    public double DiscountPercentage { get; set; }
    public int DiscountDays { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}
