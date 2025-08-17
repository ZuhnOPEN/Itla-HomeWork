using FinalHW.Class;
using FinalHW.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHW.Controllers
{
    public class HorarioController : dbContext
    {
        public static void CreateHorario()
        {
            using (var context = new dbContext())
            {
                context.Database.EnsureCreated();
                Console.WriteLine("Añadir Horario");
                Console.WriteLine("Introduce la hora de salida (HH:MM): ");
                string departureInput = Console.ReadLine();
                Console.WriteLine("Introduce la hora de llegada (HH:MM): ");
                string arrivalInput = Console.ReadLine();
                if (TimeSpan.TryParse(departureInput, out TimeSpan departureTime) &&
                    TimeSpan.TryParse(arrivalInput, out TimeSpan arrivalTime))
                {
                    var a = new Horario()
                    {
                        startTime = departureTime,
                        endTime = arrivalTime
                    };
                    context.Horarios.Add(a);
                    context.SaveChanges();
                    Console.WriteLine("Horario añadido exitosamente.");
                }
                else
                {
                    Console.WriteLine("Formato de hora inválido. Por favor, use HH:MM.");
                }
            }
        }

        public static void ViewHorarios()
        {
            using (var context = new dbContext())
            {
                var horarios = context.Horarios.ToList();
                foreach (var horario in horarios)
                {
                    Console.WriteLine($"ID: {horario.ID}, Hora de Salida: {horario.startTime}, Hora de Llegada: {horario.endTime}");
                }
            }
        }

        public static void DeleteHorario()
        {
            using (var context = new dbContext())
            {
                Console.WriteLine("Eliminar Horario");
                Console.WriteLine("Introduce el ID del horario a eliminar: ");
                if (int.TryParse(Console.ReadLine(), out int horarioId))
                {
                    var horarioToDelete = context.Horarios.FirstOrDefault(h => h.ID == horarioId);
                    if (horarioToDelete != null)
                    {
                        context.Horarios.Remove(horarioToDelete);
                        context.SaveChanges();
                        Console.WriteLine("Horario eliminado exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se encontró un horario con ese ID.");
                    }
                }
                else
                {
                    Console.WriteLine("ID inválido. Por favor, introduce un número entero.");
                }
            }
        }

        public static void AssignHorarioToRoute()
        {
            using (var context = new dbContext())
            {
                Console.WriteLine("Asignar Horario a Ruta");
                Console.WriteLine("Introduce el ID de la ruta: ");
                if (int.TryParse(Console.ReadLine(), out int routeId))
                {
                    var route = context.Rutas.Find(routeId);
                    if (route != null)
                    {
                        Console.WriteLine("Introduce el ID del horario a asignar: ");
                        if (int.TryParse(Console.ReadLine(), out int horarioId))
                        {
                            var horario = context.Horarios.Find(horarioId);
                            if (horario != null)
                            {
                                route.Horarios.Add(horario);
                                context.SaveChanges();
                                Console.WriteLine("Horario asignado a la ruta exitosamente.");
                            }
                            else
                            {
                                Console.WriteLine("No se encontró un horario con ese ID.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("ID de horario inválido. Por favor, introduce un número entero.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se encontró una ruta con ese ID.");
                    }
                }
                else
                {
                    Console.WriteLine("ID de ruta inválido. Por favor, introduce un número entero.");
                }
            }
        }

        public static void editHorario()
        {
            using (var context = new dbContext())
            {
                Console.WriteLine("Editar Horario");
                Console.WriteLine("Introduce el ID del horario a editar: ");
                if (int.TryParse(Console.ReadLine(), out int horarioId))
                {
                    var horarioToEdit = context.Horarios.Find(horarioId);
                    if (horarioToEdit != null)
                    {
                        Console.WriteLine($"Horario Actual - ID: {horarioToEdit.ID}, Hora de Salida: {horarioToEdit.startTime}, Hora de Llegada: {horarioToEdit.endTime}");
                        Console.WriteLine("Introduce la nueva hora de salida (HH:MM): ");
                        string newDepartureInput = Console.ReadLine();
                        Console.WriteLine("Introduce la nueva hora de llegada (HH:MM): ");
                        string newArrivalInput = Console.ReadLine();
                        if (TimeSpan.TryParse(newDepartureInput, out TimeSpan newDepartureTime) &&
                            TimeSpan.TryParse(newArrivalInput, out TimeSpan newArrivalTime))
                        {
                            horarioToEdit.startTime = newDepartureTime;
                            horarioToEdit.endTime = newArrivalTime;
                            context.SaveChanges();
                            Console.WriteLine("Horario editado exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("Formato de hora inválido. Por favor, use HH:MM.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se encontró un horario con ese ID.");
                    }
                }
                else
                {
                    Console.WriteLine("ID inválido. Por favor, introduce un número entero.");
                }
            }
        }


    }
}
