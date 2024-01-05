using WebMVC.Models;
using WebMVC.Models.Repository;

namespace WebMVC.Persistence.Repository;

public interface IProductRepository : IRepository<Product>
{
    void Update(Product product);
    Task SaveAsync();
}
