using BlazorReusableAutocomplete.Server.Data;
using BlazorWasmReleaseNotes.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<NorthwindContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("Northwind")));
builder.Services.AddScoped<ICustomerManager, CustomerManager>();
builder.Services.AddScoped<IProductManager, ProductManager>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");
app.MapGet("/api/companyfilter", async (string filter, [FromServices] ICustomerManager manager) =>
    Results.Ok(await manager.GetFilteredCustomers(filter))
);
app.MapGet("/api/productfilter", async (string filter, [FromServices] IProductManager manager) =>
    Results.Ok(await manager.GetFilteredProducts(filter))
);
app.Run();
