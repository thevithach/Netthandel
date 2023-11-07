using System.Linq.Expressions;
using Netthandel.DataAccess.Data;
using Netthandel.DataAccess.Repository.IRepository;
using Netthandel.Models;
using Microsoft.EntityFrameworkCore;

namespace Netthandel.DataAccess.Repository;

public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
{
    private ApplicationDbContext _db;
    public OrderHeaderRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    public void Update(OrderHeader obj)
    {
        _db.OrderHeaders.Update(obj);
    } 
}