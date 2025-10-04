using Microsoft.EntityFrameworkCore;
using WebApplication2.Models.Entity;

namespace WebApplication2.Data
{
    public class appDbcontext : DbContext
    {
        public appDbcontext(DbContextOptions<appDbcontext> options): base(options)
        { 
        }

        public DbSet<Students> Students { get; set; }
    }
}
