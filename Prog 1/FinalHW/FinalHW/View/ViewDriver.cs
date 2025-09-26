using Figgle.Fonts;
using FinalHW.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHW.View
{
    public class ViewDriver
    {
        public static void menuDriver()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine(FiggleFonts.Standard.Render("Gestion de Conductores"));

            Console.WriteLine("1. Añadir Conductor");
            Console.WriteLine("2. Mirar Conductores");
            Console.WriteLine("3. Eliminar Conductores");
            Console.WriteLine("4. Buscar Conductores");
            Console.WriteLine("5. Editar Conductores");
            Console.WriteLine("6. Salir");

            Console.WriteLine("Introduce tu opcion: ");
            string option = Convert.ToString(Console.ReadLine());

         
                switch (option)
                {
                    case "1":
                        DriverController.addDriver();
                        break;

                    case "2":
                        DriverController.viewDriver();
                        break;

                    case "3":
                        DriverController.deleteDriver();
                        break;

                    case "4":
                        DriverController.searchDriver();
                        break;

                    case "5":
                        DriverController.editDriver();
                        break;

                    case "6":
                        exit = true;
                        Console.WriteLine(FiggleFonts.Standard.Render("Adios!"));

                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("Presiona una tecla para continuar...");
                    Console.ReadKey();
                }

            }
        }
    }
    } 

           

