using Microsoft.EntityFrameworkCore;
using WebMVC.Models;

namespace WebMVC.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Category>(cat =>
        {
            cat.HasKey(c => c.CategoryId);
            cat.Property(c => c.CategoryName).IsRequired(true).HasMaxLength(20);
            cat.Property(c => c.Description).IsRequired(false);
            cat.HasMany(c => c.Products).WithOne(p => p.Category);
        });

        modelBuilder.Entity<Product>(product =>
        {
            product.HasKey(p => p.ProductId);
            product.Property(p => p.ProductName).IsRequired(true).HasMaxLength(20);
            product.Property(p => p.Description).IsRequired(false);
            product.Property(p => p.Price);
        });

        //* seed data
        modelBuilder.Entity<Category>().HasData(
            new Category()
            {
                CategoryId = Guid.Parse("0d436791-5b81-4429-84b0-b3c474765d0a"),
                CategoryName = "Electronic",
                Description = "This in electronics"
            },
            new Category()
            {
                CategoryId = Guid.Parse("91815301-2980-4f0c-98bb-4438925064cf"),
                CategoryName = "Furniture",
                Description = "This in furnitures"
            }
        );
        modelBuilder.Entity<Product>().HasData(
            new Product()
            {
                ProductId = Guid.Parse("8357b2ee-b8ca-4b78-9e90-779beb57639f"),
                ProductName = "Radio",
                Description = "This is radio",
                Price = 10,
                CategoryId = Guid.Parse("0d436791-5b81-4429-84b0-b3c474765d0a"),
            },
            new Product()
            {
                ProductId = Guid.Parse("0e50c93b-c218-4451-bdc3-bddf123134fc"),
                ProductName = "Television",
                Description = "This is television",
                Price = 10,
                CategoryId = Guid.Parse("0d436791-5b81-4429-84b0-b3c474765d0a"),
            },
            new Product()
            {
                ProductId = Guid.Parse("df7b1e62-f922-4cd6-ac31-c585064733a8"),
                ProductName = "Table",
                Description = "This is table",
                Price = 10,
                CategoryId = Guid.Parse("91815301-2980-4f0c-98bb-4438925064cf"),
            }
        );
    }
}
