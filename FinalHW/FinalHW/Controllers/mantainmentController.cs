using FinalHW.Class;
using FinalHW.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHW.Controllers
{
    public class mantainmentController : dbContext
    {
        public static void AddMantainment()
        {
            using (var db = new dbContext())
            {
                Console.Write("Fecha (yyyy-MM-dd): ");
                DateTime fecha = DateTime.Parse(Console.ReadLine());

                Console.Write("Descripción: ");
                string descripcion = Console.ReadLine();

                Console.Write("ID del auto: ");
                int carId = int.Parse(Console.ReadLine());

                var mantainment = new carMantainment
                {
                    Fecha = fecha,
                    Descripcion = descripcion,
                    CarId = carId
                };

                db.CarMantainments.Add(mantainment);
                db.SaveChanges();
                Console.WriteLine("Mantenimiento añadido correctamente.");
            }
        }

        public static void ViewMantainments()
        {
            using (var db = new dbContext())
            {
                var mantainments = db.CarMantainments.ToList();
                foreach (var m in mantainments)
                {
                    Console.WriteLine($"ID: {m.MantainmentId}, Fecha: {m.Fecha:yyyy-MM-dd}, Descripción: {m.Descripcion}, AutoID: {m.CarId}");
                }
            }
        }

        public static void EditMantainment()
        {
            using (var db = new dbContext())
            {
                Console.Write("ID de mantenimiento a editar: ");
                int id = int.Parse(Console.ReadLine());
                var mantainment = db.CarMantainments.Find(id);
                if (mantainment != null)
                {
                    Console.Write("Nueva fecha (yyyy-MM-dd): ");
                    mantainment.Fecha = DateTime.Parse(Console.ReadLine());

                    Console.Write("Nueva descripción: ");
                    mantainment.Descripcion = Console.ReadLine();

                    db.SaveChanges();
                    Console.WriteLine("Mantenimiento actualizado.");
                }
                else
                {
                    Console.WriteLine("No se encontró el mantenimiento.");
                }
            }
        }

        public static void DeleteMantainment()
        {
            using (var db = new dbContext())
            {
                Console.Write("ID de mantenimiento a eliminar: ");
                int id = int.Parse(Console.ReadLine());
                var mantainment = db.CarMantainments.Find(id);
                if (mantainment != null)
                {
                    db.CarMantainments.Remove(mantainment);
                    db.SaveChanges();
                    Console.WriteLine("Mantenimiento eliminado.");
                }
                else
                {
                    Console.WriteLine("No se encontró el mantenimiento.");
                }
            }
        }
    }

}

