using YieldHQ.Client.Resources;

namespace YieldHQ.Client;

/// <summary>
/// Main client for the YieldHQ ERP API. Provides access to all resource modules.
/// </summary>
public class YieldHQClient
{
    private readonly HttpClient _http;

    private PartnersResource? _partners;
    private ProductsResource? _products;
    private CrmResource? _crm;
    private SalesResource? _sales;
    private PurchasingResource? _purchasing;
    private InventoryResource? _inventory;
    private AccountingResource? _accounting;
    private ManufacturingResource? _manufacturing;
    private ProjectResource? _project;
    private EventsResource? _events;
    private FleetResource? _fleet;
    private MaintenanceResource? _maintenance;
    private RepairResource? _repair;
    private AuditResource? _audit;
    private RolesResource? _roles;
    private SystemResource? _system;

    /// <summary>Initializes the client with an <see cref="HttpClient"/> (typically injected via DI).</summary>
    public YieldHQClient(HttpClient http)
    {
        _http = http;
    }

    /// <summary>Partners (customers, suppliers, contacts).</summary>
    public PartnersResource Partners => _partners ??= new(_http);

    /// <summary>Products and product categories.</summary>
    public ProductsResource Products => _products ??= new(_http);

    /// <summary>CRM leads and sales teams.</summary>
    public CrmResource Crm => _crm ??= new(_http);

    /// <summary>Sale orders and order lines.</summary>
    public SalesResource Sales => _sales ??= new(_http);

    /// <summary>Purchase orders and order lines.</summary>
    public PurchasingResource Purchasing => _purchasing ??= new(_http);

    /// <summary>Inventory transfers, stock levels, warehouses, and lots.</summary>
    public InventoryResource Inventory => _inventory ??= new(_http);

    /// <summary>Accounting: accounts, invoices, bills, payments, taxes, journals.</summary>
    public AccountingResource Accounting => _accounting ??= new(_http);

    /// <summary>Manufacturing: BOMs, production orders, work centers, work orders.</summary>
    public ManufacturingResource Manufacturing => _manufacturing ??= new(_http);

    /// <summary>Projects, tasks, milestones, stages, and tags.</summary>
    public ProjectResource Project => _project ??= new(_http);

    /// <summary>Events, registrations, tickets, booths, and stages.</summary>
    public EventsResource Events => _events ??= new(_http);

    /// <summary>Fleet: vehicles, fuel/service logs, contracts, brands, models.</summary>
    public FleetResource Fleet => _fleet ??= new(_http);

    /// <summary>Maintenance: requests, equipment, categories, teams, stages.</summary>
    public MaintenanceResource Maintenance => _maintenance ??= new(_http);

    /// <summary>Repair orders with lifecycle, lines, and fees.</summary>
    public RepairResource Repair => _repair ??= new(_http);

    /// <summary>Audit logs and entity history (admin only).</summary>
    public AuditResource Audit => _audit ??= new(_http);

    /// <summary>Roles, user assignments, and module access (admin only).</summary>
    public RolesResource Roles => _roles ??= new(_http);

    /// <summary>System health check and module discovery.</summary>
    public SystemResource System => _system ??= new(_http);
}
