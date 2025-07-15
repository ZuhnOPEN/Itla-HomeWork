using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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


        public Data()
        {
            name = new List<string>();
            phone = new List<string>();
            ids = new List<int>();
            number = new List<int>();
        }

        public void addContact()
        {

            Console.Write("Introduce tu nombre: ");
            name.Add(Console.ReadLine());

            Console.Write("Introduce tu numero telefonico: ");
            phone.Add(Console.ReadLine());

            int countIDS = ids.Count + 1;
            ids.Add(countIDS);

            Console.WriteLine("Introduce un numero: ");
            number.Add(Convert.ToInt32(Console.ReadLine()));


        }


        public void viewContacts()
        {

            if (ids.Count == 0)
            {
                Console.WriteLine("No guarda na");
            }

            for (int i = 0; i < ids.Count; i++)
            {
                Console.WriteLine("╔════════════╦════════════════════╦══════════════════════╦══════════════════════");
                Console.WriteLine($"ID {ids[i]} ║ Nombre: {name[i]}, ║ Numero: {number[i]}, ║ Telefono: {phone[i]}");
            }
        }

        public void editContact()
        {
            Console.Write("Introduce el ID a editar: ");
            int idtoedit = Convert.ToInt32(Console.ReadLine());
            int index = ids.IndexOf(idtoedit);

            if (index != -1)
            {
                Console.WriteLine($"Contacto actual:ID: {ids[index]}, ║ Nombre: {name[index]}, ║ Telefono: {phone[index]}, ║ Numero: {number[index]} ");

                Console.WriteLine("Introduce el nuevo nombre: ");
                name[index] = Console.ReadLine();

                Console.WriteLine("Introduce el nuevo telefono: ");
                phone[index] = Console.ReadLine();

                Console.WriteLine("Edite el numero: ");
                number[index] = Convert.ToInt32(Console.ReadLine());
            }
        }

            public void searchContact()
        {
            Console.Write("Introduce el id a buscar");

                int searchID = Convert.ToInt32(Console.ReadLine());
                int idex = ids.IndexOf(searchID);

            if (idex != -1) {
                Console.WriteLine($"ID: {ids[idex]} ║ Nombre: {name[idex]} ║ Telefono: {phone[idex]} ║ Numero: {number[idex]} ");
            }
        }
        }

        }
        
        