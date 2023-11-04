using Netthandel.Models;

namespace Netthandel.DataAccess.Repository.IRepository;

public interface IProductRepository : IRepository<Product>
{
    void Update(Product obj);
}