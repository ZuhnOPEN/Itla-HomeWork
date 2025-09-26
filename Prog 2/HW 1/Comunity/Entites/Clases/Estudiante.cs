using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunity.Clases
{
    public class Estudiante
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string lastName { get; set; }
        public string Career { get; set; }

        public static void StudentInfo()
        {
            Estudiante estudiante = new Estudiante();
            ExAlumno exAlumno = new ExAlumno();
            int id = estudiante.ID = 12345;
            string name = estudiante.Name = "Harry";
            string lname = estudiante.lastName = "Potter";
            string career = estudiante.Career = "Wizardry";
            string status = exAlumno.Status = "Active";
            DateOnly dateOnly = exAlumno.reentry = new DateOnly(2024, 09, 01);
            Console.WriteLine("Their name is: " + name + " His last name is: " + lname + " ID: " + id + " Career: " + career + " Status: " + status + "Entry: " + dateOnly);
        }

        public static void ExStudentInfo()
        {
            ExAlumno exalumno = new ExAlumno();
            Estudiante estudiante = new Estudiante();
            int id = exalumno.ID = 54321;
            string name = exalumno.Name = "Draco";
            string lname = exalumno.lastName = "Malfoy";
            string career = exalumno.Career = "Wizardry";
            string status = exalumno.Status = "Inactive";
            DateOnly dateOnly = exalumno.exit = new DateOnly(2020, 09, 01);
            Console.WriteLine("Their name is: " + name + " His last name is: " + lname + " ID: " + id + " Career: " + career + " Status: " + status + "Exit: " + dateOnly);
        }
    }
}
