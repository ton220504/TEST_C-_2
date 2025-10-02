using ASP.NET_CORE_WEB_SQL.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_CORE_WEB_SQL.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
