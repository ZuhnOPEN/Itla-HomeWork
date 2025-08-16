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

                Console.WriteLine("Añadir Auto");
                Console.WriteLine("Introduce la placa del auto: ");
                string plaque = Console.ReadLine();
                Console.WriteLine("Introduce la cantidad de asientos: ");
                string amount = Console.ReadLine();
                Console.WriteLine("Introduce el estado del auto: ");
                string state = Console.ReadLine();

                Car newCar = new Car { Plaque = plaque, Amount = amount, State = state };
            }
        }
        public static void viewCars()
        {
            using (var view = new dbContext())
            {
                var cars = view.Cars.ToList();
                foreach (var car in cars)
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
