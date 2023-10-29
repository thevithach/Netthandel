using Microsoft.EntityFrameworkCore;
using Netthandel.Models;

namespace Netthandel.DataAccess.Data;

public class ApplicationDbContext : DbContext //Arver fra DbContext klassen bygd inn i EF Core
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
            new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
            new Category { Id = 3, Name = "History", DisplayOrder = 3 }
            
        );
    }
}