using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHW2.Domain.Entities
{
    public class Routes
    {
        public int Id { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public double Distance { get; set; }

        public string RouteName { get; set; }
        public TimeSpan EstimatedTime { get; set; }
    }
}
