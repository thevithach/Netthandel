using Netthandel.Models;

namespace Netthandel.DataAccess.Repository.IRepository;

public interface ICategoryRepository : IRepository<Category>
{
    void Update(Category obj);
}