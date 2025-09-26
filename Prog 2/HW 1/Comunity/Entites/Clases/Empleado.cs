using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunity.Clases
{
    public class Empleado
    {
        public string Name { get; set; }
        public string lastName {  get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }

        public static void EmpInfo()
        {
            Empleado empleado = new Empleado();
            string name = empleado.Name = "Ramon Girafales";
            string lname = empleado.lastName = "Familia Madrazo";
            int age = empleado.Age = 26;
            string position = empleado.Position = "FrontEnd Dev";
            decimal sal = empleado.Salary = 150;
            Console.WriteLine("Their name is: " + name + " His last name is: " + lname + " Age: " + age + " Role: " + position + " Salary: " + sal);
        }

    }
}
