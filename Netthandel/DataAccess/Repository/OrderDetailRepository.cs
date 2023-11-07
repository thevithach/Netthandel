using System.Linq.Expressions;
using Netthandel.DataAccess.Data;
using Netthandel.DataAccess.Repository.IRepository;
using Netthandel.Models;
using Microsoft.EntityFrameworkCore;

namespace Netthandel.DataAccess.Repository;

public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
{
    private ApplicationDbContext _db;
    public OrderDetailRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    public void Update(OrderDetail obj)
    {
        _db.OrderDetails.Update(obj);
    } 
}