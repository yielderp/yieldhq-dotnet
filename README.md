# YieldHQ.Client

Official .NET SDK for the [YieldHQ ERP](https://yieldhq.com) REST API.

## Installation

```
dotnet add package YieldHQ.Client
```

## Quick Start

```csharp
using YieldHQ.Client;

var client = new YieldHQClient(new YieldHQClientOptions
{
    BaseUrl = "https://your-instance.yieldhq.com",
    AccessToken = "your-api-token"
});

// List partners
var partners = await client.Partners.ListAsync();
foreach (var partner in partners.Items)
    Console.WriteLine(partner.Name);

// Create a sale order
var orderId = await client.Sales.CreateAsync(new SaleOrder
{
    PartnerId = 1,
    DateOrder = DateTime.UtcNow
});

// Auto-paginate through all products
await foreach (var product in client.Products.ListAllAsync())
    Console.WriteLine($"{product.DefaultCode} - {product.Name}");
```

## Dependency Injection

```csharp
builder.Services.AddYieldClient(options =>
{
    options.BaseUrl = "https://your-instance.yieldhq.com";
    options.AccessToken = builder.Configuration["Yield:AccessToken"]!;
});
```

Then inject `YieldHQClient` anywhere via constructor injection.

## Resources

The client exposes 16 resource modules:

| Resource | Description |
|----------|------------|
| `Partners` | Customers, suppliers, and contacts |
| `Products` | Products and categories |
| `Crm` | Leads and sales teams |
| `Sales` | Sale orders and order lines |
| `Purchasing` | Purchase orders and order lines |
| `Inventory` | Stock transfers, warehouses, lots |
| `Accounting` | Invoices, bills, payments, taxes, journals |
| `Manufacturing` | BOMs, production orders, work centers |
| `Projects` | Projects, tasks, milestones |
| `Events` | Events, registrations, tickets |
| `Fleet` | Vehicles, fuel/service logs, contracts |
| `Maintenance` | Requests, equipment, categories |
| `Repair` | Repair orders, lines, fees |
| `Audit` | Audit logs and entity history |
| `Roles` | Role management and access control |
| `System` | Health check and module info |

## Query Builder

```csharp
using YieldHQ.Client.Models;

var results = await client.Partners.ListAsync(
    new QueryParams()
        .Page(1)
        .PageSize(50)
        .Sort("name")
        .Search("acme")
        .Filter("customerRank", "1")
);
```

## Webhook Validation

```csharp
using YieldHQ.Client.Webhooks;

bool valid = WebhookValidator.Validate(requestBody, signatureHeader, webhookSecret);
```

## Error Handling

The SDK throws typed exceptions for API errors:

- `YieldAuthException` (401)
- `YieldForbiddenException` (403)
- `YieldNotFoundException` (404)
- `YieldValidationException` (400/422)
- `YieldRateLimitException` (429)
- `YieldServerException` (5xx)

## Requirements

- .NET 8.0 or .NET 9.0+

## License

MIT
