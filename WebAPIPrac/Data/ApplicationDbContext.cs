using Microsoft.EntityFrameworkCore;
using WebAPIPrac.Models;

namespace WebAPIPrac.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
        }
        public DbSet<Products> Pro { get; set; }
    }
}
