using Microsoft.AspNetCore.Mvc;
using Netthandel.DataAccess.Data;
using Netthandel.DataAccess.Repository.IRepository;
using Netthandel.Models;

namespace Netthandel.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryRepository _categoryRepo;
    public CategoryController(ICategoryRepository db)
    {
        _categoryRepo = db;
    }
    // GET
    public IActionResult Index()
    {
        List<Category> objCategoryList = _categoryRepo.GetAll().ToList();
        return View(objCategoryList);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The DisplayOrder cannot equal the name");
        }
        // if (obj.Name.ToLower() == "test")
        // {
        //     ModelState.AddModelError("", "Test is an invalid value");
        // }
        if (ModelState.IsValid)
        {
            // DBCONTEXT, DB SET, ADD (EFCORE FUNCTION)
            _categoryRepo.Add(obj);
        _categoryRepo.Save();
        TempData["success"] = "Category created successfully";
        return RedirectToAction("Index", "Category");

        }

        return View();
    }
    
    public IActionResult Edit(int? id)
    {
        if(id==null || id==0)
        {
            return NotFound();
        }

        Category? categoryFromDb = _categoryRepo.Get(u => u.Id == id);
        //Category? categoryFromDb = _db.Categories.FirstOrDefault(u => u.Id == id);
        //Category? categoryFromDb = _db.Categories.Where(u => u.Id == id).FirstOrDefault();
        if (categoryFromDb == null)
        {
            return NotFound();
        }
        return View(categoryFromDb);
    }
    [HttpPost]
    public IActionResult Edit(Category obj)
    {
        if (ModelState.IsValid)
        {
            // DBCONTEXT, DB SET, ADD (EFCORE FUNCTION)
            _categoryRepo.Update(obj);
            _categoryRepo.Save();
            TempData["success"] = "Category updated successfully";

            return RedirectToAction("Index", "Category");

        }

        return View();
    }
    
    public IActionResult Delete(int? id)
    {
        if(id==null || id==0)
        {
            return NotFound();
        }
        Category? categoryFromDb = _categoryRepo.Get(u => u.Id == id);
        //Category? categoryFromDb = _db.Categories.FirstOrDefault(u => u.Id == id);
        //Category? categoryFromDb = _db.Categories.Where(u => u.Id == id).FirstOrDefault();
        if (categoryFromDb == null)
        {
            return NotFound();
        }
        return View(categoryFromDb);
    }
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int? id)
    {
        Category? obj = _categoryRepo.Get(u => u.Id == id);
        if (obj == null)
        {
            return NotFound();
        }
        _categoryRepo.Remove(obj);
        _categoryRepo.Save();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index", "Category");
    }
    
}
    
