using Microsoft.AspNetCore.Mvc;
using Netthandel.Data;
using Netthandel.Models;

namespace Netthandel.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;
    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }
    // GET
    public IActionResult Index()
    {
        List<Category> objCategoryList = _db.Categories.ToList();
        return View(objCategoryList);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Category obj)
    {
        // DBCONTEXT, DB SET, ADD (EFCORE FUNCTION)
        _db.Categories.Add(obj);
        _db.SaveChanges();
        return RedirectToAction("Index", "Category");
    }
    
}