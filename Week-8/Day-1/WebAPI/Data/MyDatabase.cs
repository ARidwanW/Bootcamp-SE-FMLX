using Microsoft.EntityFrameworkCore;
using WebAPI.Model;

namespace WebAPI.Data;

public class MyDatabase : DbContext
{
    public MyDatabase(DbContextOptions<MyDatabase> options) : base(options)
    {

    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Category>(cat =>
        {
            cat.HasKey(c => c.CategoryId);
            cat.Property(c => c.CategoryName).IsRequired(true);
            cat.Property(c => c.Description).IsRequired(false);
            cat.HasMany(c => c.Products).WithOne(p => p.Category);
        });
        modelBuilder.Entity<Product>(pro =>
        {
            pro.HasKey(p => p.ProductId);
            pro.Property(p => p.ProductName);
            pro.Property(p => p.Description);
            pro.Property(p => p.Price);
        });
        modelBuilder.Entity<Category>().HasData(
            new Category()
            {
                CategoryId = 1,
                CategoryName = "Fruit",
                Description = "This is Fruit"
            },
            new Category()
            {
                CategoryId = 2,
                CategoryName = "Electronic",
                Description = "This is Electronic"
            }
        );
        modelBuilder.Entity<Product>().HasData(
            new Product()
            {
                ProductId = 1,
                ProductName = "Television",
                Description = "This is a television",
                Price = 100000,
                CategoryId = 2,
            },
            new Product()
            {
                ProductId = 2,
                ProductName = "Radio",
                Description = "This is a radio",
                Price = 20000,
                CategoryId = 2
            },
            new Product()
            {
                ProductId = 3,
                ProductName = "Watermelon",
                Description = "This is a watermelon",
                Price = 10000,
                CategoryId = 1
            }
        );
    }

}
