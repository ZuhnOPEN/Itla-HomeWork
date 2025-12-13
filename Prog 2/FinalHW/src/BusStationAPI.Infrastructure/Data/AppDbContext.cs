using Microsoft.EntityFrameworkCore;
using BusStationAPI.Domain.Entities;

namespace BusStationAPI.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<BusStation> BusStations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de BusStation
            modelBuilder.Entity<BusStation>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("GETUTCDATE()");

                entity.Property(e => e.UpdatedAt)
                    .IsRequired(false); 

                entity.ToTable("BusStations");
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BusStation>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    // Solo asignar CreatedAt si no ha sido asignado explícitamente
                    if (entry.Entity.CreatedAt == default(DateTime))
                    {
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                    }
                }
                else if (entry.State == EntityState.Modified)
                {
                    // Solo asignar UpdatedAt si no ha sido asignado explícitamente
                    if (entry.Entity.UpdatedAt == null || entry.Entity.UpdatedAt == default(DateTime))
                    {
                        entry.Entity.UpdatedAt = DateTime.UtcNow;
                    }
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
