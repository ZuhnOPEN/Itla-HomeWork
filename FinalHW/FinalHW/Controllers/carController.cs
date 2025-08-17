using FinalHW.Class;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHW.Controllers
{
    public class carController : dbContext
    {

        
        public static void addCar()
        {
            using (var car = new dbContext())
            {
                car.Database.EnsureCreated();

                if (!car.Rutas.Any())
                {
                    car.Rutas.Add(new Routes { Nombre = "Ruta 1", Distancia = 10.5, estimedTime = TimeSpan.FromMinutes(30) });
                    car.Rutas.Add(new Routes { Nombre = "Ruta 2", Distancia = 20.0, estimedTime = TimeSpan.FromMinutes(45) });
                    car.SaveChanges();
                }

                Console.WriteLine("Añadir Auto");
                Console.WriteLine("Introduce la placa del auto: ");
                string plaque = Console.ReadLine();
                Console.WriteLine("Introduce la cantidad de asientos: ");
                int amount;
                while (!int.TryParse(Console.ReadLine(), out amount))
                {
                    Console.WriteLine("Cantidad inválida. Intenta de nuevo:");
                }
                Console.WriteLine("Introduce el estado del auto: ");
                string state = Console.ReadLine();

                // Mostrar rutas disponibles
                Console.WriteLine("Rutas disponibles:");
                var rutasDisponibles = car.Rutas.ToList();
                foreach (var ruta in rutasDisponibles)
                {
                    Console.WriteLine($"{ruta.RouteID}: {ruta.Nombre}");
                }
                Console.WriteLine("Introduce el ID de la ruta para el auto:");
                int routeId;
                while (!int.TryParse(Console.ReadLine(), out routeId) || !rutasDisponibles.Any(r => r.RouteID == routeId))
                {
                    Console.WriteLine("ID de ruta inválido. Intenta de nuevo:");
                }

                Car newCar = new Car
                {
                    Plaque = plaque,
                    Amount = amount.ToString(), // Si cambias el modelo a int, usa Amount = amount
                    State = state,
                    RouteID = routeId
                };

                car.Cars.Add(newCar);
                car.SaveChanges();
            }
        }
        public static void viewCars()
        {
            using (var view = new dbContext())
            {
                foreach (var car in view.Cars)
                {
                    Console.WriteLine($"Placa: {car.Plaque}, Asientos: {car.Amount}, Estado: {car.State}");
                }
            }
        }
        public static void deleteCar()
        {
            Console.WriteLine("Eliminar Auto");
            Console.WriteLine("Introduce la placa del auto a eliminar: ");
            string plaque = Console.ReadLine();

            using (var delete = new dbContext())
            {
                var carToDelete = delete.Cars.FirstOrDefault(c => c.Plaque == plaque);
                if (carToDelete != null)
                {
                    delete.Cars.Remove(carToDelete);
                    delete.SaveChanges();
                    Console.WriteLine("Auto eliminado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Auto no encontrado.");
                }
            }
            
            // Aquí se eliminaría el auto de la base de datos o de una lista
        }
        public static void searchCar()
        {
            Console.WriteLine("Buscar Auto");
            Console.WriteLine("Introduce la placa del auto a buscar: ");
            string plaque = Console.ReadLine();

            // Aquí se buscaría el auto en la base de datos o en una lista
        }
    }
}
