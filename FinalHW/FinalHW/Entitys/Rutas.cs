using FinalHW.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHW.Class
{
 
        public class Routes
        {
        [Key]
            public int RouteID { get; set; }
            public string Nombre { get; set; }
            public double Distancia { get; set; }
            public TimeSpan estimedTime { get; set; }
            
            public float? Price { get; set; }

        public ICollection<Horario> Horarios { get; set; }
            public int HorarioID { get; set; }

        public ICollection<Driver> drivers { get; set; } = new List<Driver>();


        }
    }

