using Microsoft.AspNetCore.Mvc;

namespace Netthandel.Controllers;

public class CategoryController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}