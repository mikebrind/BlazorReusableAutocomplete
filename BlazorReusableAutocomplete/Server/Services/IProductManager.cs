using BlazorReusableAutocomplete.Shared;

namespace BlazorWasmReleaseNotes.Server.Services;
public interface IProductManager
{
    Task<List<Product>> GetFilteredProducts(string filter);
}