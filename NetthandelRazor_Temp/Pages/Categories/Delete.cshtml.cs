using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NetthandelRazor_Temp.Data;
using NetthandelRazor_Temp.Models;

namespace NetthandelRazor_Temp.Pages.Categories;
[BindProperties]
public class Delete : PageModel
{
    private readonly ApplicationDbContext _db;
    public Category Category { get; set; }
    public Delete(ApplicationDbContext db)
    {
        _db = db;
    }
    public void OnGet(int? id)
    {
        if(id != null && id != 0)
        {
            Category = _db.Categories.Find(id);
        }
    }

    public IActionResult OnPost()
    {
        Category? obj = _db.Categories.Find(Category.Id);
        if (obj == null)
        {
            return NotFound();
        }

        _db.Categories.Remove(obj);
         _db.SaveChanges();
         TempData["success"] = "Category deleted successfully";

         return RedirectToPage("Index");
        
    }
}