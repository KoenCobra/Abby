using AbbyWeb.Model;
using Microsoft.EntityFrameworkCore;

namespace AbbyData
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category>? Categories { get; set; }
    }
}
