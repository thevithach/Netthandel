using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NetthandelRazor_Temp.Data;
using NetthandelRazor_Temp.Models;

namespace NetthandelRazor_Temp.Pages.Categories;

public class Create : PageModel
{
    private readonly ApplicationDbContext _db;
    [BindProperty]
    public Category Category { get; set; }
    public Create(ApplicationDbContext db)
    {
        _db = db;
    }
    public void OnGet()
    {
    }
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        _db.Categories.Add(Category);
        _db.SaveChanges();
        TempData["success"] = "Category created successfully";
        return RedirectToPage("Index");
    }
}