using BulkyBookWeb.Data;
using BulkyBookWeb.interfaces;
using BulkyBookWeb.Models;
using BulkyBookWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers;

public class CategoryController : Controller{

    private readonly ICategoryServices _catServices;

    public CategoryController(ICategoryServices catServices)
    {
        _catServices = catServices;
    }

    public IActionResult Index(){   
        IEnumerable<Category> objCategoryList = _catServices.GetCategories();
        return View(objCategoryList);
    }

    public IActionResult Create(){
        return View();
    }

    [HttpPost]
    public IActionResult Create(Category obj){
        if(ModelState.IsValid){
            if(_catServices.AddCategory(obj))    
                TempData["success"] = "Category Created Successfully";
            return RedirectToAction("Index", "Category");
        }
        return View(obj);
    }

    public IActionResult Edit(int? Id){
        if(Id == null || Id == 0)   return NotFound();
        var categoryFromDb = _catServices.GetCategoryById(Id.Value);
        if(categoryFromDb == null)  return NotFound();
        return View(categoryFromDb);
    }

    [HttpPost]
    public IActionResult Edit(Category obj){
        if(ModelState.IsValid){
            if(_catServices.UpdateCategory(obj))
                TempData["success"] = "Category Updated Successfully";
            return RedirectToAction("Index", "Category");
        }
        return View(obj);
    }

    public IActionResult Delete(int? Id){
        if(Id == null || Id == 0)   return NotFound();
        var categoryFromDb = _catServices.GetCategoryById(Id.Value);
        if(categoryFromDb == null)  return NotFound();
        return View(categoryFromDb);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int? Id){
        Category categoryFromDb = _catServices.GetCategoryById(Id.Value);
        if(categoryFromDb == null)  return NotFound();
        _catServices.DeleteCategory(categoryFromDb);
        TempData["success"] = "Category Deleted Successfully";
        return RedirectToAction("Index", "Category");
    }
}