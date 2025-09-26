using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunity.Clases
{
    internal class Teacher : Empleado
    {
        public string Class;
        public string Subject;

        public static void TeacherInfo()
        {
            Teacher teacher = new Teacher();
            Empleado empleado = new Empleado();

            string name = empleado.Name = "Severus Snape";
            string lname = empleado.lastName = "Potter";
            int age = empleado.Age = 45;
            string position = empleado.Position = "Professor";
            decimal sal = empleado.Salary = 200;
            string clase = teacher.Class = "Potions";
            string subject = teacher.Subject = "Defence";
            Console.WriteLine("Their name is: " + name + " His last name is: " + lname + " Age: " + age + " Role: " + position + " Salary: " + sal + " Class: " + clase + " Subject: " + subject);
        }
    }
}
