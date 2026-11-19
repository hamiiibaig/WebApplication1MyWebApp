using WebApplication1MyWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1MyWebApp.DataFolder
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}
