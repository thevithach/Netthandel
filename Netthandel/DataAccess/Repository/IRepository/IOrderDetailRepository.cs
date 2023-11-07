using Netthandel.Models;

namespace Netthandel.DataAccess.Repository.IRepository;

public interface IOrderDetailRepository : IRepository<OrderDetail>
{
    void Update(OrderDetail obj);
}