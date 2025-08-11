using Azure;
using Figgle.Fonts;
using FinalHW.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FinalHW.Controllers
{
    public class DriverController : dbContext
    {
        static void addDriver()
        {
            Console.WriteLine(FiggleFonts.Standard.Render("Añadir"));


            using (var drive = new dbContext())
            {
                Console.WriteLine("Introduce el nombre del conductor: ");
                string fname = Convert.ToString(Console.ReadLine());
                string lName = Convert.ToString(Console.ReadLine());
                int edad = Convert.ToInt32(Console.ReadLine());
                string ciudad = Convert.ToString(Console.ReadLine());
                string pais = Convert.ToString(Console.ReadLine());
                string numero = Convert.ToString(Console.ReadLine());

                var a = new Driver() { Name = fname, lastName = lName, age = edad, city = ciudad, country = pais, phone = numero };

            }
        }

        static void viewDriver()
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

        static void deleteDriver()
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
                                Console.WriteLine("Introduce el ID del conductor a eliminar: ");
                                int delID = Convert.ToInt32(Console.ReadLine());

                                using (var searchdriv = new dbContext())
                                {
                                    Console.WriteLine("Conductores disponibles a eliminar: ");
                                    foreach (var d in searchdriv.Driver)
                                    {
                                        Console.WriteLine($"ID: {d.driverID} Nombre: {d.Name} Apellido: {d.lastName} Edad: {d.age} Ciudad: {d.city} Pais: {d.country} Numero: {d.phone}");
                                    }

                                    Console.WriteLine("Desea borrar este usuario? ");
                                    Console.WriteLine("1. Si 2. No");
                                    var del = searchdriv.Driver.Find(delID);

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


        static void editDriver()
        {



            using (var view = new dbContext)
            {
                foreach (var v in view.Driver)
                {
                    Console.WriteLine($"ID: {v.driverID} Nombre: {v.Name} Apellido: {v.lastName} Edad: {v.age} Ciudad: {v.city} Pais: {v.country}, Telefono: {v.phone} ");
                }
            }

            string ename = Convert.ToString(Console.ReadLine());
            string edlname = Convert.ToString(Console.ReadLine());
            int eage = Convert.ToInt32(Console.ReadLine());
            string eciudad = Convert.ToString(Console.ReadLine());
            string epais = Convert.ToString(Console.ReadLine());
            string ephone = Convert.ToString(Console.ReadLine());

            var edit = new Driver() { Name = ename, lastName = edlname, age = eage, city = eciudad, country = epais, phone = ephone }; 
        }
    }
}
