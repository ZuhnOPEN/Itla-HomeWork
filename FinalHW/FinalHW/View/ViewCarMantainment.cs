using FinalHW.Entitys;
using FinalHW.Class;
using System;
using System.Linq;
using FinalHW.Controllers;

namespace FinalHW.View
{
    public static class ViewCarMantainment
    {
        public static void MenuCarMantainment()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine(Figgle.Fonts.FiggleFonts.Standard.Render("Mantenimiento de Autos"));  
                Console.WriteLine("1. Añadir mantenimiento");
                Console.WriteLine("2. Ver mantenimientos");
                Console.WriteLine("3. Editar mantenimiento");
                Console.WriteLine("4. Eliminar mantenimiento");
                Console.WriteLine("5. Salir");
                Console.Write("Selecciona una opción: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        mantainmentController.AddMantainment();
                        break;
                    case "2":
                        mantainmentController.ViewMantainments();
                        break;
                    case "3":
                        mantainmentController.EditMantainment();
                        break;
                    case "4":
                        mantainmentController.DeleteMantainment();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
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
            
        
        

