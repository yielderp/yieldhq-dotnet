using YieldHQ.Client.Models;
using YieldHQ.Client.Models.Products;

namespace YieldHQ.Client.Resources;

/// <summary>Provides access to the Products API.</summary>
public class ProductsResource : ResourceBase
{
    internal ProductsResource(HttpClient http) : base(http) { }

    /// <summary>List products with optional pagination.</summary>
    public Task<PagedResult<Product>> ListAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<Product>("/api/v1/products", query, ct);

    /// <summary>List all products, auto-paginating.</summary>
    public IAsyncEnumerable<Product> ListAllAsync(CancellationToken ct = default) =>
        ListAllAsync<Product>("/api/v1/products", ct: ct);

    /// <summary>Get a single product by ID.</summary>
    public Task<Product> GetAsync(int id, CancellationToken ct = default) =>
        GetAsync<Product>($"/api/v1/products/{id}", ct);

    /// <summary>Create a new product.</summary>
    public Task<int> CreateAsync(Product product, CancellationToken ct = default) =>
        CreateAsync<int>("/api/v1/products", product, ct);

    /// <summary>Update an existing product.</summary>
    public Task UpdateAsync(int id, Product product, CancellationToken ct = default) =>
        UpdateAsync($"/api/v1/products/{id}", product, ct);

    /// <summary>Delete a product.</summary>
    public Task DeleteAsync(int id, CancellationToken ct = default) =>
        DeleteAsync($"/api/v1/products/{id}", ct);

    /// <summary>List product categories.</summary>
    public Task<PagedResult<ProductCategory>> ListCategoriesAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<ProductCategory>("/api/v1/products/categories", query, ct);
}
