using YieldHQ.Client.Models;
using YieldHQ.Client.Models.Accounting;

namespace YieldHQ.Client.Resources;

/// <summary>Provides access to the Accounting API.</summary>
public class AccountingResource : ResourceBase
{
    internal AccountingResource(HttpClient http) : base(http) { }

    // Accounts
    /// <summary>List chart of accounts entries.</summary>
    public Task<PagedResult<Account>> ListAccountsAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<Account>("/api/v1/accounting/accounts", query, ct);

    /// <summary>Get a single account by ID.</summary>
    public Task<Account> GetAccountAsync(int id, CancellationToken ct = default) =>
        GetAsync<Account>($"/api/v1/accounting/accounts/{id}", ct);

    /// <summary>Create a new account.</summary>
    public Task<int> CreateAccountAsync(Account account, CancellationToken ct = default) =>
        CreateAsync<int>("/api/v1/accounting/accounts", account, ct);

    /// <summary>Update an existing account.</summary>
    public Task UpdateAccountAsync(int id, Account account, CancellationToken ct = default) =>
        UpdateAsync($"/api/v1/accounting/accounts/{id}", account, ct);

    // Invoices, Bills, Entries
    /// <summary>List invoices (customer).</summary>
    public Task<PagedResult<AccountMove>> ListInvoicesAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<AccountMove>("/api/v1/accounting/invoices", query, ct);

    /// <summary>List bills (vendor).</summary>
    public Task<PagedResult<AccountMove>> ListBillsAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<AccountMove>("/api/v1/accounting/bills", query, ct);

    /// <summary>List journal entries.</summary>
    public Task<PagedResult<AccountMove>> ListEntriesAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<AccountMove>("/api/v1/accounting/entries", query, ct);

    // Moves (generic)
    /// <summary>Get a single accounting move by ID.</summary>
    public Task<AccountMove> GetMoveAsync(int id, CancellationToken ct = default) =>
        GetAsync<AccountMove>($"/api/v1/accounting/moves/{id}", ct);

    /// <summary>Create a new accounting move.</summary>
    public Task<int> CreateMoveAsync(AccountMove move, CancellationToken ct = default) =>
        CreateAsync<int>("/api/v1/accounting/moves", move, ct);

    /// <summary>Update an existing accounting move.</summary>
    public Task UpdateMoveAsync(int id, AccountMove move, CancellationToken ct = default) =>
        UpdateAsync($"/api/v1/accounting/moves/{id}", move, ct);

    /// <summary>Post (confirm) an accounting move.</summary>
    public Task PostMoveAsync(int id, CancellationToken ct = default) =>
        ActionAsync($"/api/v1/accounting/moves/{id}/post", ct: ct);

    /// <summary>Cancel an accounting move.</summary>
    public Task CancelMoveAsync(int id, CancellationToken ct = default) =>
        ActionAsync($"/api/v1/accounting/moves/{id}/cancel", ct: ct);

    /// <summary>List lines for a specific accounting move.</summary>
    public Task<PagedResult<AccountMoveLine>> ListMoveLinesAsync(int moveId, QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<AccountMoveLine>($"/api/v1/accounting/moves/{moveId}/lines", query, ct);

    // Payments
    /// <summary>List payments.</summary>
    public Task<PagedResult<Payment>> ListPaymentsAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<Payment>("/api/v1/accounting/payments", query, ct);

    /// <summary>Get a single payment by ID.</summary>
    public Task<Payment> GetPaymentAsync(int id, CancellationToken ct = default) =>
        GetAsync<Payment>($"/api/v1/accounting/payments/{id}", ct);

    /// <summary>Create a new payment.</summary>
    public Task<int> CreatePaymentAsync(Payment payment, CancellationToken ct = default) =>
        CreateAsync<int>("/api/v1/accounting/payments", payment, ct);

    /// <summary>Post (confirm) a payment.</summary>
    public Task PostPaymentAsync(int id, CancellationToken ct = default) =>
        ActionAsync($"/api/v1/accounting/payments/{id}/post", ct: ct);

    // Taxes
    /// <summary>List taxes.</summary>
    public Task<PagedResult<Tax>> ListTaxesAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<Tax>("/api/v1/accounting/taxes", query, ct);

    /// <summary>Get a single tax by ID.</summary>
    public Task<Tax> GetTaxAsync(int id, CancellationToken ct = default) =>
        GetAsync<Tax>($"/api/v1/accounting/taxes/{id}", ct);

    /// <summary>Create a new tax.</summary>
    public Task<int> CreateTaxAsync(Tax tax, CancellationToken ct = default) =>
        CreateAsync<int>("/api/v1/accounting/taxes", tax, ct);

    // Journals
    /// <summary>List journals.</summary>
    public Task<PagedResult<Journal>> ListJournalsAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<Journal>("/api/v1/accounting/journals", query, ct);

    /// <summary>Get a single journal by ID.</summary>
    public Task<Journal> GetJournalAsync(int id, CancellationToken ct = default) =>
        GetAsync<Journal>($"/api/v1/accounting/journals/{id}", ct);

    /// <summary>Create a new journal.</summary>
    public Task<int> CreateJournalAsync(Journal journal, CancellationToken ct = default) =>
        CreateAsync<int>("/api/v1/accounting/journals", journal, ct);

    // Payment Terms
    /// <summary>List payment terms.</summary>
    public Task<PagedResult<PaymentTerm>> ListPaymentTermsAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<PaymentTerm>("/api/v1/accounting/payment-terms", query, ct);
}
