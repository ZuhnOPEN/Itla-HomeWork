using Figgle.Fonts;
using FinalHW.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHW.Controllers
{
    public class RoutesController : dbContext
    {
        public static void addRoute()
        {
            Console.WriteLine(FiggleFonts.Standard.Render("Añadir"));

            using (var route = new dbContext())
            {
                Console.WriteLine("Introduce el nombre de la ruta");
                string routeName = Convert.ToString(Console.ReadLine());

                Console.WriteLine("Introduce la distancia aproximada");
                double length = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Introduce el tiempo del viaje (HH:MM)");
                string time = Convert.ToString(Console.ReadLine());
                TimeSpan tiempoEstimado;

                Console.WriteLine("Introduce la tarifa de la ruta");
                float price = Convert.ToSingle(Console.ReadLine());



                if (TimeSpan.TryParse(time, out tiempoEstimado))
                {
                    var add = new Routes
                    {
                        Nombre = routeName,
                        Distancia = length,
                        estimedTime = tiempoEstimado,
                        Price = price
                    
                    };

                    Console.WriteLine($"Tiempo estiamdo guardado: {add.estimedTime}");

                    route.Add(add);
                    route.SaveChanges();
                }
                else
                {
                    {
                        Console.WriteLine("Formato invalido, Ej 1:30 para una 1 hora y 30 minutos");
                    }
                }



            }
        }

        public static void viewRoutes()
        {
            Console.WriteLine(FiggleFonts.Standard.Render("View"));

            using (var view = new dbContext())
            {
                foreach (var v in view.Rutas)
                {
                    Console.WriteLine($"ID {v.RouteID} Ruta: {v.Nombre} Distancia: {v.Distancia} Tiempo estimado: {v.estimedTime} Tarifa: {v.Price}");
                }
            }
        }

        public static void deleteRoute()
        {
            Console.WriteLine(FiggleFonts.Standard.Render("Eliminar"));

            using (var delete = new dbContext())
            {
                Console.WriteLine("Rutas disponibles a eliminar: ");

                foreach (var d in delete.Rutas)
                {
                    Console.WriteLine($"ID: {d.RouteID} Ruta: {d.Nombre} Distancia: {d.Distancia} Timepo estimado: {d.estimedTime}");
                }

                Console.WriteLine("Introduce el ID a eliminar: ");
                int delRoute = Convert.ToInt32(Console.Read());

                var showRoute = new Routes() { RouteID = delRoute };

                using (var del = new dbContext())
                {
                    var sup = delete.Cars.Find(delRoute);

                    int option = Convert.ToInt32(Console.ReadLine());
                }

                Console.WriteLine("Desea borrar este usuario?");
                Console.WriteLine("1. Si 2. No");
                var supRoute = delete.Rutas.Find(delRoute);

                int decide = Convert.ToInt32(Console.ReadLine());

                if (decide == 1)
                {
                    delete.Remove<Routes>(supRoute);
                    delete.SaveChanges();
                    Console.WriteLine("La ruta ha sido eliminada correctamente");
                }
                else
                {
                    Console.WriteLine("La ruta no sera eliminada");
                }
            }

        }

        public static void editRoute()
        {
            Console.WriteLine("Introduce el ID a editar");
            int sRoute = Convert.ToInt32(Console.ReadLine());

            using (var edit = new dbContext())
            {
                var found = edit.Rutas.Find(sRoute);
                Console.WriteLine($"Ruta: {found.Nombre} Distancia: {found.Distancia} Tiempo estimado: {found.estimedTime}");

            }

            string editRoute = Convert.ToString(Console.ReadLine());
            double editLength = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Introduce el tiempo del viaje (HH:MM)");

            TimeSpan editEstimed;

            string time = Console.ReadLine();

            if (TimeSpan.TryParse(time, out editEstimed))
            {
                var Routes = new Routes
                {
                    Nombre = editRoute,
                    Distancia = editLength,
                    estimedTime = editEstimed
                };

                Console.WriteLine($"Tiempo estiamdo guardado: {Routes.estimedTime}");
            }
            else
            {
                {
                    Console.WriteLine("Formato invalido, Ej 1:30 para una 1 hora y 30 minutos");
                }
            }
        }

        public static void addDriverToRoute()
        {
            Console.WriteLine(FiggleFonts.Standard.Render("Añadir"));
            using (var add = new dbContext())
            {
                Console.WriteLine("Introduce el ID de la ruta a la que se le asignara un conductor: ");
                int routeID = Convert.ToInt32(Console.ReadLine());
                var route = add.Rutas.Find(routeID);
                if (route != null)
                {
                    Console.WriteLine("Introduce el ID del conductor a asignar: ");
                    int driverID = Convert.ToInt32(Console.ReadLine());
                    var driver = add.Driver.Find(driverID);
                    if (driver != null)
                    {
                        route.drivers.Add(driver);
                        add.SaveChanges();
                        Console.WriteLine($"Conductor {driver.Name} asignado a la ruta {route.Nombre}");
                    }
                    else
                    {
                        Console.WriteLine("Conductor no encontrado.");
                    }
                }
                else
                {
                    Console.WriteLine("Ruta no encontrada.");
                }
            }
            }

            public static void searchRoute()
        {
            Console.WriteLine("Introduce el nombre de la ruta a buscar: ");
            string routeName = Convert.ToString(Console.ReadLine());
            using (var search = new dbContext())
            {
                var foundRoute = search.Rutas.FirstOrDefault(r => r.Nombre.Equals(routeName, StringComparison.OrdinalIgnoreCase));
                if (foundRoute != null)
                {
                    Console.WriteLine($"Ruta encontrada: ID {foundRoute.RouteID}, Nombre: {foundRoute.Nombre}, Distancia: {foundRoute.Distancia}, Tiempo estimado: {foundRoute.estimedTime}");
                }
                else
                {
                    Console.WriteLine("Ruta no encontrada.");
                }
            }
        }

        }
}
