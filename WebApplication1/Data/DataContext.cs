using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Data
{
    public class DataContext(DbContextOptions options) : DbContext(options)
    {
        public required DbSet<AppUser> Users { get; set; }
    }
}
