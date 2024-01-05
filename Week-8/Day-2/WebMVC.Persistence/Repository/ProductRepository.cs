using WebMVC.Data;
using WebMVC.Models;
using WebMVC.Models.Repository;

namespace WebMVC.Persistence.Repository;

public class ProductRepository : Repository<Product>, IProductRepository
{
    private readonly ApplicationDbContext _db;
    public ProductRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }

    public void Update(Product product)
    {
        _db.Products.Update(product);
    }

}
