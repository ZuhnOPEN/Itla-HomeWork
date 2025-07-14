using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fuckfuck.puta
{
    public class Data
    {
        public List<string> name { get; set; }
        public List<string> phone { get; set; }
        public List<int> ids { get; set; }
        public List<int> number { get; set; }

        public void addContact()
        {
            Data data = new Data();

            data.name = new List<string>();
            data.phone = new List<string>();
            data.number = new List<int>();
            data.ids = new List<int>();

            Console.WriteLine("Introduce tu nombre");
            data.name.Add(Console.ReadLine());

            Console.WriteLine("Introduce tu numero telefonico: ");
            data.phone.Add(Console.ReadLine());

            int countIDS = data.ids.Count + 1;
            data.ids.Add(countIDS);

            Console.WriteLine("Introduce un numero: ");
            data.number.Add(Convert.ToInt32(Console.ReadLine()));
            
            
        }


        public void viewContacts(Data data)
        {
            for (int i = 0; i < data.ids.Count; i++)
            {
                Console.WriteLine($"ID {data.ids} - Nombre: {data.name}, - Numero: {data.number}, -Telefono: {data.phone}");
            }
        }
        }
    }