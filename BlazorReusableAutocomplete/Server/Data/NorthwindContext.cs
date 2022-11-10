using BlazorReusableAutocomplete.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorReusableAutocomplete.Server.Data;

public partial class NorthwindContext : DbContext
{
    public NorthwindContext()
    {
    }

    public NorthwindContext(DbContextOptions<NorthwindContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; } = null!;
    public virtual DbSet<Product> Products { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasIndex(e => e.City, "IX_Customers_City");

            entity.HasIndex(e => e.CompanyName, "IX_Customers_CompanyName");

            entity.HasIndex(e => e.PostalCode, "IX_Customers_PostalCode");

            entity.HasIndex(e => e.Region, "IX_Customers_Region");

            entity.Property(e => e.CustomerId)
                .HasColumnType("nchar(5)")
                .HasColumnName("CustomerID");

            entity.Property(e => e.Address).HasColumnType("nvarchar(60)");

            entity.Property(e => e.City).HasColumnType("nvarchar(15)");

            entity.Property(e => e.CompanyName).HasColumnType("nvarchar(40)");

            entity.Property(e => e.ContactName).HasColumnType("nvarchar(30)");

            entity.Property(e => e.ContactTitle).HasColumnType("nvarchar(30)");

            entity.Property(e => e.Country).HasColumnType("nvarchar(15)");

            entity.Property(e => e.Fax).HasColumnType("nvarchar(24)");

            entity.Property(e => e.Phone).HasColumnType("nvarchar(24)");

            entity.Property(e => e.PostalCode).HasColumnType("nvarchar(10)");

            entity.Property(e => e.Region).HasColumnType("nvarchar(15)");
        });


        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "IX_Products_CategoriesProducts");

            entity.HasIndex(e => e.CategoryId, "IX_Products_CategoryID");

            entity.HasIndex(e => e.ProductName, "IX_Products_ProductName");

            entity.HasIndex(e => e.SupplierId, "IX_Products_SupplierID");

            entity.HasIndex(e => e.SupplierId, "IX_Products_SuppliersProducts");

            entity.Property(e => e.ProductId)
                .HasColumnType("integer")
                .HasColumnName("ProductID");

            entity.Property(e => e.CategoryId)
                .HasColumnType("integer")
                .HasColumnName("CategoryID");

            entity.Property(e => e.Discontinued)
                .HasColumnType("bit")
                .HasDefaultValueSql("0");

            entity.Property(e => e.DiscontinuedDate).HasColumnType("datetime");

            entity.Property(e => e.ProductName).HasColumnType("nvarchar(40)");

            entity.Property(e => e.QuantityPerUnit).HasColumnType("nvarchar(20)");

            entity.Property(e => e.ReorderLevel)
                .HasColumnType("smallint")
                .HasDefaultValueSql("0");

            entity.Property(e => e.SupplierId)
                .HasColumnType("integer")
                .HasColumnName("SupplierID");

            entity.Property(e => e.UnitPrice)
                .HasColumnType("money")
                .HasDefaultValueSql("0");

            entity.Property(e => e.UnitsInStock)
                .HasColumnType("smallint")
                .HasDefaultValueSql("0");

            entity.Property(e => e.UnitsOnOrder)
                .HasColumnType("smallint")
                .HasDefaultValueSql("0");

        });
      

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
