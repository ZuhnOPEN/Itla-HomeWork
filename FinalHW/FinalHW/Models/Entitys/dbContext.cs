using FinalHW.Entitys;
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
        public DbSet<Routes> Rutas { get; set; }
        public DbSet<Driver> Driver { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Horario> Horarios { get; set; }

        public DbSet<carMantainment> CarMantainments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=Sichova;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>()
                .HasMany(d => d.rutas)
                .WithMany(r => r.drivers)
                .UsingEntity(j => j.ToTable("DriverRutas"));

         

            modelBuilder.Entity<Routes>()
                .HasKey(r => r.RouteID);

            modelBuilder.Entity<Routes>()
                    .HasMany(r => r.Horarios)
                    .WithMany(h => h.Rutas)
                    .UsingEntity(j => j.ToTable("RouteHorario"));

        } 
    }
}
