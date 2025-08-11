using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHW.Class
{
    public class Car
    {
        public int carID { get; set; }
        public string typeOfCar { get; set; }
        public string carBrand { get; set; }
        public string drivenBy { get; set; }
        public string mileage { get; set; }

        public Driver driver { get; set; }
    }
}
