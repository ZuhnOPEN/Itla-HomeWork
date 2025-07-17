Console.WriteLine("Bienvenido a mi lista de Contactes");


//names, lastnames, addresses, telephones, emails, ages, bestfriend
bool runing = true;
List<int> ids = new List<int>();
List<string> names = new List<string>();
List<string> lastnames = new List<string>();
List<string> addresses = new List<string>();
List<string> telephones = new List<string>();
List<string> emails = new List<string>();
List<int> ages = new List<int>();
List<bool> bestFriends = new List<bool>();


while (runing)
{
    Console.WriteLine(@"1. Agregar Contacto     2. Ver Contactos    3. Buscar Contactos     4. Modificar Contacto   5. Eliminar Contacto    6. Salir");
    Console.WriteLine("Digite el número de la opción deseada");

    int typeOption = Convert.ToInt32(Console.ReadLine());

    switch (typeOption)
    {
        case 1:
            {
                //Console.WriteLine("Digite el nombre de la persona");
                //string name = Console.ReadLine();
                //Console.WriteLine("Digite el apellido de la persona");
                //string lastname = Console.ReadLine();
                //Console.WriteLine("Digite la dirección");
                //string address = Console.ReadLine();
                //Console.WriteLine("Digite el telefono de la persona");
                //string phone = Console.ReadLine();
                //Console.WriteLine("Digite el email de la persona");
                //string email = Console.ReadLine();
                //Console.WriteLine("Digite la edad de la persona en números");
                //int age = Convert.ToInt32(Console.ReadLine());
                //Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No");
                ////var temp = Convert.ToInt32(Console.ReadLine());
                ////bool isBestFriend;
                ////if (temp == 1)
                ////{ isBestFriend = true; }
                ////else
                ////{ isBestFriend = false; }
                //bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

                //var id = ids.Count + 1;
                //ids.Add(id);
                //names.Add(id, name);
                //lastnames.Add(id, lastname);
                //addresses.Add(id, address);
                //telephones.Add(id, phone);
                //emails.Add(id, email);
                //ages.Add(id, age);
                //bestFriends.Add(id, isBestFriend);

                AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);

            }
            break;
        case 2: //extract this to a method
            {
                Console.WriteLine($"Nombre          Apellido            Dirección           Telefono            Email           Edad            Es Mejor Amigo?");
                Console.WriteLine($"____________________________________________________________________________________________________________________________");

                for (int i = 0; i < ids.Count; i++) {
                    Console.WriteLine($"Nombre: {names[i]}, | Apellido: {lastnames[i]}, Direccion: {addresses[i]}, Telefono: {telephones[i]}, Correo: {emails[i]}, Edad: {ages[i]}, Es tu mejor amigo?: {bestFriends[i]}");

                }

            }
            break;
        case 3: //search
            {
                Console.Write("Introudce el ID a buscar: ");

                int searchID = Convert.ToInt32(Console.ReadLine());
                int idex = ids.IndexOf(searchID);

                if (idex != -1)
                {
                    Console.WriteLine($"Nombre: {names[idex]} | Apellido {lastnames[idex]}, | Direccion {addresses[idex]}, | Telefono {telephones[idex]}, | Correo {emails[idex]}, Edad | {ages[idex]}, Es mejor amigo?: {bestFriends[idex]}");
                }

            }
            break;
        case 4: //modify
            {
                Console.Write("Introduce el ID a editar: ");
                int idtoedit = Convert.ToInt32(Console.ReadLine());
                int index = ids.IndexOf(idtoedit);

                if (index != -1)
                {
                    Console.WriteLine($"Nombre: {names[index]}, Apellido: {lastnames[index]}, Direccion {addresses[index]}, Telefono: {telephones[index]}, Correo {emails[index]}, Edad: {ages[index]}, Es tu mejor amigo?: {bestFriends[index]}");

                    Console.WriteLine("Introduce el nuevo nombre: ");
                    names[index] = Console.ReadLine();

                    Console.WriteLine("Introduce el nuevo apellido: ");
                    lastnames[index] = Console.ReadLine();

                    Console.WriteLine("Introduce la nueva direccion: ");
                    addresses[index] = Console.ReadLine();

                    Console.WriteLine("Introduce el nuevo telefono: ");
                    telephones[index] = Console.ReadLine();

                    Console.WriteLine("Introduce el nuevo correo: ");
                    emails[index] = Console.ReadLine();

                    Console.WriteLine("Introduce la nueva edad: ");
                    ages[index] = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Sigue siendo tu mejor amigo? ");
                    bestFriends[index] = Convert.ToBoolean(Console.ReadLine());

                }
            }
            break;
        case 5: //delete
            {
                Console.WriteLine("Introduce el ID a borrar: ");
                int delID = Convert.ToInt32(Console.ReadLine());
                int delete = ids.IndexOf(delID);

                if (delete != -1)
                {
                    Console.WriteLine("Contacto a eliminar ");
                    Console.WriteLine($"Nombre {names[delete]}, Apellido: {lastnames[delete]}, Direccion {addresses[delete]}, Telefono: {telephones[delete]}, Correo {emails[delete]}, Edad: {ages[delete]}, Es tu mejor amigo?: {bestFriends[delete]}");

                    Console.WriteLine("1. Si 2. No");
                    int decide = Convert.ToInt32(Console.ReadLine());

                    if (decide != 1)
                    {
                        ids.RemoveAt(delete);
                        names.RemoveAt(delete);
                        telephones.RemoveAt(delete);
                        addresses.RemoveAt(delete);
                        emails.RemoveAt(delete);
                        ages.RemoveAt(delete);
                        bestFriends.RemoveAt(delete);
                        Console.WriteLine("El contacto ha sido eliminado");
                    }
                    else
                    {
                        Console.WriteLine("No se ha podido eliminar el contacto");
                    }




                }
            }
            break;
        case 6:
            runing = false;
            break;
        default:
            Console.WriteLine("Tu eres o te haces el idiota?");
            break;
    }
}


static void AddContact(List<int> ids, List<string> names, List<string> lastnames, List<string> addresses, List<string> telephones, List<string> emails, List<int> ages, List<bool> bestFriends)
{
    Console.WriteLine("Digite el nombre de la persona");
    string name = Console.ReadLine();
    Console.WriteLine("Digite el apellido de la persona");
    string lastname = Console.ReadLine();
    Console.WriteLine("Digite la dirección");
    string address = Console.ReadLine();
    Console.WriteLine("Digite el telefono de la persona");
    string phone = Console.ReadLine();
    Console.WriteLine("Digite el email de la persona");
    string email = Console.ReadLine();
    Console.WriteLine("Digite la edad de la persona en números");
    int age = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No");

    bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

    var id = ids.Count + 1;
    ids.Add(id);
    names.Add(name);
    lastnames.Add(lastname);
    addresses.Add(address);
    telephones.Add(phone);
    emails.Add(email);
    ages.Add(age);
    bestFriends.Add(isBestFriend);
}