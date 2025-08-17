using FinalHW.Class;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalHW.Entitys
{
    public class carMantainment
    {
        [Key]
        public int MantainmentId { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }

        // Relación con Car
        
        public Car Car { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }
       
    }
}
