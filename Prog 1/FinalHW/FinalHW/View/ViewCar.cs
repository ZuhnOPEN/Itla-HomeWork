using Figgle.Fonts;
using FinalHW.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHW.View
{
    public class ViewCar
    {
        public static void menuCar()
        {

            bool exit = false;
            while (!exit)
            {

                Console.Clear();
                Console.WriteLine(FiggleFonts.Standard.Render("Gestion de Autos"));

                Console.WriteLine("1. Añadir Auto");
                Console.WriteLine("2. Mirar Autos");
                Console.WriteLine("3. Eliminar Autos");
                Console.WriteLine("4. Buscar Autos");
                Console.WriteLine("5. Salir");
                Console.WriteLine("Introduce tu opcion: ");

                string carOption = Convert.ToString(Console.ReadLine());

                switch (carOption)
                {
                    case "1":
                        carController.addCar();
                        break;
                    case "2":
                        carController.viewCars();
                        break;
                    case "3":
                        carController.deleteCar();
                        break;
                    case "4":
                        carController.searchCar();
                        break;

                    case "5":
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

