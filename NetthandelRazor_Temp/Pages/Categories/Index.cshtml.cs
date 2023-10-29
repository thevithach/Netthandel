using Microsoft.AspNetCore.Mvc.RazorPages;
using NetthandelRazor_Temp.Data;
using NetthandelRazor_Temp.Models;

namespace NetthandelRazor_Temp.Pages.Categories;

public class Index : PageModel
{
    private readonly ApplicationDbContext _db;
    public List<Category> CategoryList { get; set; }
    public Index(ApplicationDbContext db)
    {
        _db = db;
    }
    public void OnGet()
    {
        CategoryList = _db.Categories.ToList();
    }
}