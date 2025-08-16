using Figgle;
using Figgle.Fonts;
using FinalHW.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHW.Class
{
    public class Driver
    {


        public int driverID { get; set; }
        public string Name { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string? phone { get; set; }


        public ICollection<Routes> rutas { get; set; }
    }
}
