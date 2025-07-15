using System.Linq;
using fuckfuck.puta;


int option = 0;

Data data = new Data();


do
{
    Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════════════════════");
    Console.WriteLine("1. Agregar contacto 2. Ver Contacto 3. Editar Contacto 4. Borrar Contacto 5. Buscar Contacto 6. Salir");
    Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════════════════════");




    option = Convert.ToInt32(Console.ReadLine());
    switch (option)
    {

        default:
            break;

        case 1:
            data.addContact();
            break;

        case 2:
            data.viewContacts();
            break;

        case 3: data.editContact(); 
            break;

        case 5: data.searchContact();
            break;



    }
} while (option != 6);


