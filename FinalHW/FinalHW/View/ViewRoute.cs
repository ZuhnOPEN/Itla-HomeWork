using Figgle.Fonts;
using FinalHW.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHW.View
{
    public class ViewRoute
    {
        public static void menuRoute()
        {
            bool exit = false;

            while (!exit) { 
            Console.Clear();
            Console.WriteLine(FiggleFonts.Standard.Render("Gestion de Rutas"));
            Console.WriteLine("1. Añadir Ruta");
            Console.WriteLine("2. Mirar Rutas");
            Console.WriteLine("3. Buscar Ruta");
            Console.WriteLine("4. Eliminar Ruta");
            Console.WriteLine("5. Añadir Conductor a Ruta");

            string select = Convert.ToString(Console.ReadLine());
            switch (select)
            {
                case "1":
                    RoutesController.addRoute();
                    break;

                case "2":
                    RoutesController.viewRoutes();
                    break;

                case "3":
                    RoutesController.searchRoute();
                    break;

                case "4":
                    RoutesController.deleteRoute();
                    break;

                case "5":
                    RoutesController.addDriverToRoute();
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
