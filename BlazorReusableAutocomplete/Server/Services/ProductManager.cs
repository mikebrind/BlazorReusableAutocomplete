using BlazorReusableAutocomplete.Server.Data;
using BlazorReusableAutocomplete.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorWasmReleaseNotes.Server.Services;

public class ProductManager : IProductManager
{
    private readonly NorthwindContext context;

    public ProductManager(NorthwindContext context) => this.context = context;

    public async Task<List<Product>> GetFilteredProducts(string filter) =>
        await context.Products
        .Where(x => x.ProductName.ToLower().Contains(filter.ToLower()))
        .OrderBy(x => x)
        .ToListAsync();
}
