using Figgle;
using Figgle.Fonts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHW.Class
{
    public class Driver
    {


        public int driverID { get; set; }
        public string Name { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string? phone { get; set; }





        
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

                var add = new Driver() = { Name = fname, lastName = lName, age = edad, city = pais, phone = numero};
            }
        }

        static void viewDriver()
        {
            using (var view = new dbContext())
            {
                {
                    foreach (var d in view.Driver)
                    {
                        Console.WriteLine($"ID {d.driverID} Nombre: {d.Name} Apellido {d.lastName} Edad: {d.age} Ciudad: {d.city} Telefono {d.phone} CarID: {d.carID}");
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
                do {
                    
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
                                    foreach (var d in searchdriv.Driver) { 
                                    Console.WriteLine($"ID: {d.ID} Nombre: {d.Name} Apellido: {d.lastName} Edad: {d.age} Ciudad: {d.city} Pais: {d.country} Numero: {d.phone}");
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
                            } break;
                    }
                } while (option != 6);
                
            }
        }
    }
}
