using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers;

public class CategoryController : Controller{

    private readonly ApplicationDbContext _dbContext;

    public CategoryController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index(){   
        //objCategoryList stores the data from database
        IEnumerable<Category> objCategoryList = _dbContext.Categories;
        //and this objCategoryList model is send to the view page
        return View(objCategoryList);
    }

    public IActionResult Create(){
        return View();
        //return Content("Create Action in progress...");
    }

    [HttpPost]
    public IActionResult Create(Category obj){
        if(ModelState.IsValid){
            _dbContext.Categories.Add(obj);
            _dbContext.SaveChanges();
            TempData["success"] = "Category Created Successfully";
            return RedirectToAction("Index", "Category");
        }
        return View(obj);
    }

    public IActionResult Edit(int? Id){
        if(Id == null || Id == 0)   return NotFound();
        var categoryFromDb = _dbContext.Categories.Find(Id);
        if(categoryFromDb == null)  return NotFound();
        return View(categoryFromDb);
    }

    [HttpPost]
    public IActionResult Edit(Category obj){
        if(ModelState.IsValid){
            _dbContext.Categories.Update(obj);
            _dbContext.SaveChanges();
            TempData["success"] = "Category Updated Successfully";
            return RedirectToAction("Index", "Category");
        }
        return View(obj);
    }

    public IActionResult Delete(int? Id){
        if(Id == null || Id == 0)   return NotFound();
        var categoryFromDb = _dbContext.Categories.Find(Id);
        if(categoryFromDb == null)  return NotFound();
        return View(categoryFromDb);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int? Id){
        var categoryFromDb = _dbContext.Categories.Find(Id);
        if(categoryFromDb == null)  return NotFound();
        _dbContext.Categories.Remove(categoryFromDb);
        _dbContext.SaveChanges();
        TempData["success"] = "Category Deleted Successfully";
        return RedirectToAction("Index", "Category");
    }
}