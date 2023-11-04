using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Netthandel.Models;

namespace Netthandel.ViewModels;

public class ProductVM
{
    public Product Product { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> CategoryList { get; set; }
    
}