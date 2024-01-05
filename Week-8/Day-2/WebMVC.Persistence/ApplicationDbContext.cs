using Microsoft.EntityFrameworkCore;
using WebMVC.Models;

namespace WebMVC.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
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
    }
}
