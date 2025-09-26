using Figgle.Fonts;
using FinalHW.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHW.View
{
    public class ViewHorario
    {
        public static void menuHorario()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine(FiggleFonts.Standard.Render("Gestion de Horarios"));
                Console.WriteLine("1. Añadir Horario");
                Console.WriteLine("2. Mirar Horarios");
                Console.WriteLine("3. Eliminar Horario");
                Console.WriteLine("4. Salir");
                string select = Convert.ToString(Console.ReadLine());
                switch (select)
                {
                    case "1":
                        HorarioController.CreateHorario();
                        break;
                    case "2":
                        HorarioController.ViewHorarios();
                        break;
                    case "3":
                        HorarioController.DeleteHorario();
                        break;
                    case "4":
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
