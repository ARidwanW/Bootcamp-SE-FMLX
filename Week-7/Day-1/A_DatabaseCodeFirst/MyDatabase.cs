using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace A_DatabaseCodeFirst;

public class MyDatabase : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    //* Sqlite
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseSqlite(@"FileName=./MyDatabase.db");
    // }

    //* Postgre
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"Host=localhost:5432;
        Database=MyPostgreDatabase;
        Username=postgres;
        Password=postgres");
    }

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Category>(category =>
        {
            category.HasKey(c => c.CategoryId);
            category.Property(c => c.CategoryName).IsRequired().HasMaxLength(20);
            category.Property(c => c.Description).IsRequired(false).HasMaxLength(100);
            // category.HasMany(c => c.Products);
            category.HasMany(c => c.Products);
        });

        //! Max length not supported in sqlite
        // model.Entity<Category>().Property(c => c.CategoryName).HasMaxLength(20).IsRequired();

        model.Entity<Product>(product =>
        {
            product.HasKey(p => p.ProductId);
            product.Property(p => p.ProductName).IsRequired().HasMaxLength(20);
            product.Property(p => p.Cost).HasColumnName("ProductPrice").HasColumnType("Money");
            // product.HasOne(p => p.Category);
        });

        //* Seeding
        model.Entity<Category>().HasData(
            new Category()
            {
                CategoryId = 1,
                CategoryName = "Electronic",
                Description = "This is Electronic."
            },
            new Category()
            {
                CategoryId = 2,
                CategoryName = "Fruit",
                Description = "This is a Fruit."
            }

            // in postgree it will return exception
            // new Category()
            // {
            //     CategoryId = 3,
            //     CategoryName = "TestMaxLengthTestMaxLengthTestMaxLengthTestMaxLengthTestMaxLengthTestMaxLength",
            //     Description = "This is a Fruit."
            // }
        );

        model.Entity<Product>().HasData(
            new Product()
            {
                ProductId = 1,
                ProductName = "Radio",
                CategoryId = 1
            },
            new Product()
            {
                ProductId = 2,
                ProductName = "TV",
                CategoryId = 1
            }
        );
    }
}
