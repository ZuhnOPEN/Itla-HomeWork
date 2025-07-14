using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fuckfuck.puta
{
    public class Class2
    {
      
            public int numeros { get; set; }
            public List<string> names { get; set; } = new List<string>();
            public List<string> phone { get; set; } = new List<string>();


            public void display()
            {
                
                Console.WriteLine("Introduce tu nombre: ");
                names.Add(Console.ReadLine());
            Console.WriteLine("Introduce tu numero: ");
                phone.Add(Console.ReadLine());
            }

            public void displaylist()
            {
                Console.Clear();
                Console.WriteLine("Contactos guardados");
                foreach (var name in names)
                {
                    Console.WriteLine(name);
                }
            }
        }
    }

