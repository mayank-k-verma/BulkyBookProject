using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace BulkyBookWeb.interfaces;

public interface ICategoryServices
{
    public IEnumerable<Category> GetCategories();
    public bool AddCategory(Category obj);
    public Category GetCategoryById(int Id);
    public bool UpdateCategory(Category obj);
    public bool DeleteCategory(Category obj);
}