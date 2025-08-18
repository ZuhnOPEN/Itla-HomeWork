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
                Console.WriteLine("Apellido: ");
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

                drive.Driver.Add(a);
                drive.SaveChanges();

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

                Console.WriteLine("1. Ver conductores disponibles");
                Console.WriteLine("2. Eliminar conductor");
                Console.WriteLine("3. Salir");

                option = Convert.ToInt32(Console.ReadLine());

                using (var showdrive = new dbContext())
                {
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Conductores disponibles a eliminar: ");
                            if (showdrive.Driver == null)
                            {
                                Console.WriteLine("No hay conductores disponibles");
                            }
                            else
                            {
                                foreach (var d in showdrive.Driver)
                                {
                                    Console.WriteLine($"ID {d.driverID} Nombre: {d.Name} Apellido {d.lastName} Edad: {d.age} Ciudad: {d.city} Telefono {d.phone}");
                                }
                            }
                            break;

                        case 2:
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
                                    delete.Remove(del);
                                    delete.SaveChanges();
                                    Console.WriteLine("El conductor se ha borrado correctamente");
                                }
                            }
                            else
                            {
                                Console.WriteLine("El conductor no sera eliminado");
                            }
                            break;

                    }

                }
            }
                      
            }
        


        public static void editDriver()
        {

            using (var edit = new dbContext())
            {
            
            Console.WriteLine("Introduce el ID a buscar");
            int searchID = Convert.ToInt32(Console.ReadLine());

            using (var view = new dbContext())
            {


              var found = view.Driver.Find(searchID);                      
              Console.WriteLine($"ID: {found.driverID} Nombre: {found.Name} Apellido: {found.lastName} Edad: {found.age} Ciudad: {found.city} Pais: {found.country}, Telefono: {found.phone} ");
                
            }
            Console.WriteLine("Introduce los nuevos datos del conductor: ");
                Console.WriteLine("Nombre: ");
                string ename = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Apellido: ");
                string edlname = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Edad: ");
                int eage = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ciudad: ");
                string eciudad = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Pais: ");
                string epais = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Telefono: ");
                string ephone = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Estado del conductor (opcional): ");
                string eDisp = Convert.ToString(Console.ReadLine());

            var change = new Driver() {driverID = searchID, Name = ename, lastName = edlname, age = eage, city = eciudad, country = epais, phone = ephone };

                edit.Driver.UpdateRange(change);
                
                edit.SaveChanges();

            }
        }

        public static void searchDriver()
        {
            Console.Write("Introduce el ID a buscar");

            using (var s = new dbContext())
            {
                Driver driver = new Driver();
                int driverID = driver.driverID;

                int searchID = Convert.ToInt32(Console.ReadLine());

                var found = s.Driver.Find(searchID);
                if (found != null)
                {
                    Console.WriteLine($"ID: {found.driverID} Nombre: {found.Name} Apellido: {found.lastName} Edad: {found.age} Ciudad: {found.city} Pais: {found.country}, Telefono: {found.phone}");
                }
                else
                {
                    Console.WriteLine("Conductor no encontrado");
                }

            }

            
        }

    }
}
