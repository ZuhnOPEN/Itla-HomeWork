using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHW.Class
{
    public class dbContext : DbContext
    {
        public DbSet<Rutas> Rutas { get; set; }
        public DbSet<Driver> Driver { get; set; }
        public DbSet<Car> Cars { get; set; }
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=Sichova:Trusted_Connection=True;");
        }
    }
}
