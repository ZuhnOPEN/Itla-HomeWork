using Azure;
using Figgle.Fonts;
using FinalHW.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FinalHW.Controllers
{
    public class DriverController : dbContext
    {
        public static void addDriver()
        {
            Console.WriteLine(FiggleFonts.Standard.Render("Añadir"));


            using (var drive = new dbContext())
            {
                drive.Database.EnsureCreated();

                Console.WriteLine("Introduce el nombre del conductor: ");
                string fname = Convert.ToString(Console.ReadLine());
                Console.Write("Apellido");
                string lName = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Edad");
                int edad = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ciudad");
                string ciudad = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Pais: ");
                string pais = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Numero telefonico");
                string numero = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Estado del conductor (opcional)");
                string driverState = Convert.ToString(Console.ReadLine());

                var a = new Driver() { Name = fname, lastName = lName, age = edad, city = ciudad, country = pais, phone = numero};

            }
        }

        public static void viewDriver()
        {
            using (var view = new dbContext())
            {
                {
                    foreach (var d in view.Driver)
                    {
                        Console.WriteLine($"ID {d.driverID} Nombre: {d.Name} Apellido {d.lastName} Edad: {d.age} Ciudad: {d.city} Telefono {d.phone}");
                    }
                }

            }
        }

        public static void deleteDriver()
        {
            Console.WriteLine(FiggleFonts.Standard.Render("Eliminar"));

            using (var delete = new dbContext())
            {
                int option = 0;
                do
                {

                    option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            {

                                using (var showdrive = new dbContext())
                                {
                                    Console.WriteLine("Conductores disponibles a eliminar: ");
                                    foreach (var d in showdrive.Driver)
                                    {
                                        Console.WriteLine($"ID: {d.driverID} Nombre: {d.Name} Apellido: {d.lastName} Edad: {d.age} Ciudad: {d.city} Pais: {d.country} Numero: {d.phone}");
                                    }


                                    Console.WriteLine("Introduce el ID del conductor a eliminar: ");
                                    int delID = Convert.ToInt32(Console.ReadLine());

                                    var delDriver = new Driver() { driverID = delID };

                                    using (var deletedriver = new dbContext())
                                    {
                                        var d = showdrive.Driver.Find(delID);
                                        Console.WriteLine($"ID: {d.driverID} Nombre: {d.Name} Apellido: {d.lastName} Edad: {d.age} Ciudad: {d.city} Pais {d.country} Numero: {d.phone}");
                                    }

                                    Console.WriteLine("Desea borrar este usuario? ");
                                    Console.WriteLine("1. Si 2. No");
                                    var del = showdrive.Driver.Find(delID);

                                    int decide = Convert.ToInt32(Console.ReadLine());

                                    if (decide == 1)
                                    {
                                        using (var remove = new dbContext())
                                        {
                                            delete.Remove<Driver>(del);
                                            delete.SaveChanges();
                                            Console.WriteLine("El conductor se ha borrado correctamente");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("El conductor no sera eliminado");
                                    }
                                }
                            }
                            break;
                    }
                } while (option != 6);

            }
        }


        public static void editDriver()
        {


            Console.WriteLine("Introduce el ID a buscar");
            int searchID = Convert.ToInt32(Console.ReadLine());

            using (var view = new dbContext())
            {
              var found = view.Driver.Find(searchID);                      
              Console.WriteLine($"ID: {found.driverID} Nombre: {found.Name} Apellido: {found.lastName} Edad: {found.age} Ciudad: {found.city} Pais: {found.country}, Telefono: {found.phone} ");
                
            }

            string ename = Convert.ToString(Console.ReadLine());
            string edlname = Convert.ToString(Console.ReadLine());
            int eage = Convert.ToInt32(Console.ReadLine());
            string eciudad = Convert.ToString(Console.ReadLine());
            string epais = Convert.ToString(Console.ReadLine());
            string ephone = Convert.ToString(Console.ReadLine());
            string eDisp = Convert.ToString(Console.ReadLine());

            var edit = new Driver() { Name = ename, lastName = edlname, age = eage, city = eciudad, country = epais, phone = ephone }; 
        }

        public static void searchDriver()
        {
            Console.Write("Introduce el ID a buscar");

            using (var s = new dbContext())
            {
                Driver driver = new Driver();
                int driverID = driver.driverID;

                int searchID = Convert.ToInt32(Console.ReadLine());
                
            }

            
        }

    }
}
