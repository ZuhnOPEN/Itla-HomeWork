using FinalHW.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHW.Class
{
 
        public class Routes
        {
            public int ID { get; set; }
            public string Nombre { get; set; }
            public double Distancia { get; set; }
            public TimeSpan estimedTime { get; set; }

            public Horario Horario { get; set; }
            public List<Horario> Horarios { get; set; } = new List<Horario>();
         
            public ICollection<Driver> drivers { get; set; }


        }
    }

