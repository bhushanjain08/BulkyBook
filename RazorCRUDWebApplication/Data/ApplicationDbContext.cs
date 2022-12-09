using Microsoft.EntityFrameworkCore;
using RazorCRUDWebApplication.Model;

namespace RazorCRUDWebApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Category { get; set; }
    }
}
