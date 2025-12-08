using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalHW2.Domain.Core;

namespace FinalHW2.Domain.Entities
{
    public class Schedule
    {
        Drivers Driver = new Drivers();
        public int Id { get; set; }
        public Vehicles Vehicle { get; set; }
        public Drivers driver { get; set; }
        public Routes Route { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}
