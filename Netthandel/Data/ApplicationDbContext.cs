using Microsoft.EntityFrameworkCore;
using Netthandel.Models;

namespace Netthandel.Data;

public class ApplicationDbContext : DbContext //Arver fra DbContext klassen bygd inn i EF Core
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    public DbSet<Category> Categories { get; set; }
}