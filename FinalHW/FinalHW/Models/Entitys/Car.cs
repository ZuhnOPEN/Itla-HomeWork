using FinalHW.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHW.Class
{
    public class Car
    {
        public int ID { get; set; }
        public string Plaque { get; set; }
        public string Amount { get; set; }
        public string State { get; set; }

        //fk de ruta
        [ForeignKey("Rutas")]
        public int RutasRouteID { get; set; }
        public Routes Rutas { get; set; }

        //Chofer asignado al auto
        public int? driverID { get; set; }
        public Driver Driver { get; set; }
    }
}
