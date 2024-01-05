using WebMVC.Models;
using WebMVC.Models.Repository;

namespace WebMVC.Persistence.Repository;

public interface ICategoryRepository : IRepository<Category>
{
    void Update(Category category);
    Task SaveAsync();
}
