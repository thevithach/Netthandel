using System.Linq.Expressions;
using Netthandel.DataAccess.Data;
using Netthandel.DataAccess.Repository.IRepository;
using Netthandel.Models;
using Microsoft.EntityFrameworkCore;

namespace Netthandel.DataAccess.Repository;

public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
{
    private ApplicationDbContext _db;
    public ShoppingCartRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    public void Update(ShoppingCart obj)
    {
        _db.ShoppingCarts.Update(obj);
    } 
}