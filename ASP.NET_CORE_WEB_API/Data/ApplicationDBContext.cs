using ASP.NET_CORE_WEB_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_CORE_WEB_API.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
