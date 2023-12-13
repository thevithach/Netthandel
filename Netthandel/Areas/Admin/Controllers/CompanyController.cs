using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Netthandel.DataAccess.Repository.IRepository;
using Netthandel.Models;
using Netthandel.Utility;
using Netthandel.ViewModels;

namespace Netthandel.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]
public class CompanyController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public CompanyController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        List<Company> objProductList = _unitOfWork.Company.GetAll().ToList();
        
        return View(objProductList);
    }

    public IActionResult Upsert(int? id) 
    {
        //IEnumerable<SelectListItem> CategoryList =
        //ViewBag.CategoryList = CategoryList;
        //ViewData["CategoryList"] = CategoryList;
       
        if(id == null || id == 0)
        {
            //create
            return View(new Company());
        }
        else
        {
            //update
            Company companyObj = _unitOfWork.Company.Get(u => u.Id == id);
            return View(companyObj);
        }
    }

    [HttpPost]
    public IActionResult Upsert(Company CompanyObj)
    {
        if (ModelState.IsValid)
        {

            if (CompanyObj.Id == 0)
            {
                _unitOfWork.Company.Add(CompanyObj);
            }
            else
            {
                _unitOfWork.Company.Update(CompanyObj);
            }
            _unitOfWork.Save();
            TempData["success"] = "Product created successfully";
            return RedirectToAction("Index", "Company");
        }
        else
        {
            return View(CompanyObj);

        }

    }
    /*public IActionResult Delete(int? id)
    {
        if(id==null || id==0)
        {
            return NotFound();
        }
        Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);
        if (productFromDb == null)
        {
            return NotFound();
        }
        return View(productFromDb);
    }
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int? id)
    {
        Product? obj = _unitOfWork.Product.Get(u => u.Id == id);
        if (obj == null)
        {
            return NotFound();
        }
        _unitOfWork.Product.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "Product deleted successfully";
        return RedirectToAction("Index", "Product");
    }*/

    #region API CALLS

    [HttpGet]
    public IActionResult GetAll()
    {
        List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
        return Json(new { data = objCompanyList });
    }
    
    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        var CompanyToBeDeleted = _unitOfWork.Company.Get(u => u.Id == id);
        if (CompanyToBeDeleted == null)
        {
            return Json(new { success = false, message = "Error while deleting" });
        }
        
        _unitOfWork.Company.Remove(CompanyToBeDeleted);
        _unitOfWork.Save();
        return Json(new { success = true, message = "Delete Successful" });
    }
    
    #endregion
}