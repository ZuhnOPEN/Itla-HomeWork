using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FinalHW2.Infrastructure.Context
{
    public class DriverContext : DbContext
    { 
        public DriverContext(DbContextOptions<DriverContext> options) : base(options)
        {

        }
        public DbSet<FinalHW2.Domain.Core.Drivers> Drivers { get; set; }
        public DbSet<FinalHW2.Domain.Entities.Vehicles> Vehicles { get; set; }
        public DbSet<FinalHW2.Domain.Entities.Routes> Routes { get; set; }
        public DbSet<FinalHW2.Domain.Entities.Schedule> Schedules { get; set; }

    }
}
