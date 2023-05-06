using DotNetCoreJQuery.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreJQuery.DataContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
        public DbSet<Category> Categories { get; set; }
    }
}
