using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunity.Clases
{
    public class Administrator : Empleado
    {
        public int levelOfSecurity;

        public static void AdmInfo()
        {
            Administrator administrator = new Administrator();
            Empleado empleado = new Empleado();


            string name = empleado.Name = "Randolf Vladimir";
            string lname = empleado.lastName = "Martinez Beltre";
            int age = empleado.Age = 21;
            string position = empleado.Position = "Server Management";
            decimal sal = empleado.Salary = 100;
            int level = administrator.levelOfSecurity = 4;

            Console.WriteLine("Their name is: ", name, "His last name is: ", lname, "Age: ", age, "Role: ", position, "Salary: ", sal, "Level of security: ", level);
        }
    }
}



