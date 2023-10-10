using BulkyBookWeb.Data;
using BulkyBookWeb.interfaces;
using BulkyBookWeb.Models;
using Org.BouncyCastle.Crypto.Prng.Drbg;

namespace BulkyBookWeb.Services;

public class CategoryServices : ICategoryServices{

    private readonly ApplicationDbContext _dbContext;

    public CategoryServices(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Category> GetCategories(){
        //objCategoryList stores the data from database
        IEnumerable<Category> objCategoryList = _dbContext.Categories;
        return objCategoryList;
    }

    public bool AddCategory(Category obj){
        try{
            _dbContext.Categories.Add(obj);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception){
            return false;
        }
    }

    public Category GetCategoryById(int Id){
        //var here bcs Find() can return null if no object is found
        var categoryFromDb = _dbContext.Categories.Find(Id);
        //returned value is being checked for null in the controller
        return categoryFromDb!;
    }

    public bool UpdateCategory(Category obj){
        try{
            _dbContext.Categories.Update(obj);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception){
            return false;
        }
    }

    public bool DeleteCategory(Category obj){
        try{
            _dbContext.Categories.Remove(obj);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception){
            return false;
        }
    }
}