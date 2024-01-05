using WebMVC.Data;
using WebMVC.Models;
using WebMVC.Models.Repository;

namespace WebMVC.Persistence.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private readonly ApplicationDbContext _db;
    public CategoryRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }

    public void Update(Category category)
    {
        _db.Categories.Update(category);
    }

}
