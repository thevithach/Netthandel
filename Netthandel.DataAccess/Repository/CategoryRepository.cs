using System.Linq.Expressions;
using Netthandel.DataAccess.Data;
using Netthandel.DataAccess.Repository.IRepository;
using Netthandel.Models;
using Microsoft.EntityFrameworkCore;

namespace Netthandel.DataAccess.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private ApplicationDbContext _db;
    public CategoryRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    public void Update(Category obj)
    {
        _db.Categories.Update(obj);
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}