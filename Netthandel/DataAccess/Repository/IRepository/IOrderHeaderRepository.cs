using Netthandel.Models;

namespace Netthandel.DataAccess.Repository.IRepository;

public interface IOrderHeaderRepository : IRepository<OrderHeader>
{
    void Update(OrderHeader obj);
}