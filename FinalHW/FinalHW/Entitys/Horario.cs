using FinalHW.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHW.Entitys
{
    public class Horario
    {
        public int ID { get; set; }
        public TimeSpan startTime { get; set; }
        public TimeSpan endTime { get; set; }

        public ICollection<Routes> Rutas { get; set; }



    }
}
