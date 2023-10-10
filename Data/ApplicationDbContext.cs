using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;

namespace BulkyBookWeb.Data;

public class ApplicationDbContext : DbContext{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Category> Categories {get; set;}
}