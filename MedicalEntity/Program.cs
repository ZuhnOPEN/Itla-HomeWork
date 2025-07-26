using EntityProyect.Class;
using System.Text;

class program
{
    static void Main(string[] args)
    {
        using (var context = new userContext())
        {
            int option = 0;
            context.Database.EnsureCreated();
            do
            {
                Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════════════════════════");
                Console.WriteLine("1. Añadir paciente 2. Ver pacientes 3. Editar pacientes 4. Buscar pacientes 5. Eliminar paciente 6. Salir");
                Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════════════════════════");

                option = Convert.ToInt32(Console.ReadLine());
           
                switch (option)
                {
                    //añadir
                    case 1:
                        {
                            
                            Console.WriteLine("Escribe tu nombre: ");
                            string fname = Convert.ToString(Console.ReadLine());

                            Console.WriteLine("Introduce la cedula del paciente: ");
                            int addCedula = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Escribe tu apellido: ");
                            string lname = Convert.ToString(Console.ReadLine());

                            Console.WriteLine("Escribe tu correo: ");
                            string correo = Convert.ToString(Console.ReadLine());

                            Console.WriteLine("Escribe tu numero de telefono");
                            string numero = Convert.ToString(Console.ReadLine());

                            Console.WriteLine("Es tu mejor amigo? ");
                            bool bestie = Convert.ToBoolean(Console.ReadLine());

                            var usr1 = new user() { Name = fname, Cedula = addCedula, lastName = lname, Email = correo, Numero = numero, bestFriend = bestie };

                            context.users.Add(usr1);
                            context.SaveChanges();
                        }
                        break;
                    //ver
                    case 2:
                        { 
                            if(context.users == null)
                            {
                                Console.WriteLine("No hay usuarios en la base de datos");
                            }else
                            {
                                foreach (var u in context.users)
                                {
                                    Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
                                    Console.WriteLine($"ID: {u.Id} | Nombre: {u.Name}  | Cedula: {u.Cedula} | Apellido: {u.lastName} | Correo: {u.Email} | Telefono: {u.Numero} | Es tu mejor amigo? {u.bestFriend}");
                                    Console.WriteLine("════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");

                                }
                            }
                                
                        }break;
                        //editar usuarios
                    case 3:
                        {
                            using (var edit = new userContext())
                            {
                                Console.WriteLine("Selecciona el ID a editar: ");
                                int id = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Introduzca el nuevo nombre: ");
                                string editName = Convert.ToString(Console.ReadLine());

                                Console.WriteLine("Introduzca el nuevo apellido: ");
                                string editApellido = Convert.ToString(Console.ReadLine());

                                Console.WriteLine("Edite el correo del usuario:");
                                string editEmail = Convert.ToString(Console.ReadLine());

                                Console.WriteLine("Edita el numero telefonico del usuario: ");
                                string editNumb = Convert.ToString(Console.ReadLine());

                                Console.WriteLine("Cambia la relacion entre el usuario y tu");
                                bool editFriend = Convert.ToBoolean(Console.ReadLine());

                                var usrEdit = new user() {Id = id, Name = editName, lastName = editApellido, Email = editEmail, Numero = editNumb, bestFriend = editFriend };

                                context.UpdateRange(usrEdit);
                                context.SaveChanges();

                            }
                        }break;
                        //buscar pacientes
                    case 4:
                        {
                            Console.WriteLine("Introduce el nombre a buscar: ");
                            int searchID = Convert.ToInt32(Console.ReadLine());

                            using (var search = new userContext())
                            {
                               var found = search.users.Find(searchID);
                                Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
                                Console.WriteLine($"ID: {found.Id} | Nombre: {found.Name} | Cedula: {found.Cedula} | Apellido {found.lastName} | Correo: {found.Email} | Numero: {found.Numero} | Estado: {found.bestFriend}");
                                Console.WriteLine("═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");

                            }
                        }
                        break;

                        //elimiar usuarios
                    case 5:
                        {
                            Console.WriteLine("Introduce el ID del paciente a eliminar: ");
                            int delID = Convert.ToInt32(Console.ReadLine());

                            var delUser = new user() { Id = delID};

                            Console.WriteLine("Deseas borrar este usuario?");
                            int decide = Convert.ToInt32(Console.ReadLine());

                            if (decide == 1)
                            {
                                using (var delete = new userContext())
                                { 
                                    delete.Remove<user>(delUser);
                                    delete.SaveChanges();
                                }
                            }
                            else
                            {
                                Console.WriteLine("No se eliminara este usuario.");
                            }

                        
                        }break;
                }
            } while (option != 6);


        }
    }
}

//This is the biggest piece of bullshit i ever wrote




//⠀⠀⠀⠀⠀⠀⠀⠈⠀⠀⠀⠀⠀⠀⠀⠈⠈⠉⠉⠈⠈⠈⠉⠉⠉⠉⠉⠉⠉⠉⠙⠻⣄⠉⠉⠉⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠓⣄⠀⠀⢀⠀⢀⣀⣤⠄⠀⠀⠀⠀⠀⠀⠀
//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢷⣉⣩⣤⠴⠶⠶⠒⠛⠛⠀⠀⠀⠀⠀
//⠀⠀⠀⠀⠀⠀⠀⠀⣴⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣧⠤⠶⠒⠚⠋⠉⠀⠀⠀⠀⠀⠀⠀
//⠀⠀⠀⠀⠀⠀⢀⣾⡍⠀⠀⠀⠀⠀⠀⠀⠀⢠⣾⣫⣭⣷⠶⢶⣤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
//⠶⠶⠖⠚⠛⠛⣹⠏⠀⠀⠀⠀⠀⠀⠀⠀⠴⠛⠛⠉⡁⠀⠀⠙⠻⣿⣷⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⢹⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
//⠀⠀⠀⠀⠀⢠⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⣿⡷⠷⢿⣦⣤⣈⡙⢿⣿⢆⣴⣤⡄⠀⠀⠀⠀⢸⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
//⠀⠀⣠⣤⡀⣸⡄⠀⠀⠀⠀⠀⠀⠀⢀⣤⣿⣿⣟⣩⣤⣴⣤⣌⣿⣿⣿⣦⣹⣿⢁⣿⣿⣄⣀⡀⠀⢸⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
//⠀⢠⣿⠋⠻⢿⡁⠀⠀⠀⠀⠀⠀⠀⠀⢸⡿⠿⠛⢦⣽⣿⣿⢻⣿⣿⣿⣿⠋⠁⠘⣿⣿⣿⣿⣿⣿⣼⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
//⠀⢸⣿⠁⠀⠀⠙⠆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠒⠿⣿⣯⣼⣿⡿⠟⠃⠀⠀⠀⣿⣿⣿⣿⣿⡛⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
//⠀⢸⣧⣴⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣺⠟⠃⠀⠀⠀⠀⠀⠀⠙⣿⣿⣿⣿⣿⣿⢁⣀⣀⣀⣀⣀⣠⣀⣀⢀⢀⢀
//⠀⠀⢿⠿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⡆⠙⠛⠛⠙⢻⣶⣶⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿
//⣿⣿⡇⠀⠘⠃⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡞⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
//⡟⢿⣿⣆⠀⣸⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢄⡼⠁⢀⣀⡀⠀⠀⠀⣦⣄⠀⣠⡄⣸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
//⣷⣬⢻⣿⡿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣧⣰⣿⡿⠿⠦⢤⣴⣿⣿⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
//⣿⣿⣸⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⠛⠛⠒⣿⣿⣿⡿⠟⠹⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
//⣿⠸⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⡖⠀⢠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
//⡿⣾⣿⣸⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣆⣀⣀⣤⣴⣶⣶⣾⣿⣷⣦⣴⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
//⡇⣿⣿⡛⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⢾⡟⠛⠛⠻⠛⠛⠛⠿⠿⠿⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
//⠓⢁⣬⣿⠇⠀⠀⠀⠀⠀⢠⡀⠀⠀⠀⠀⠀⢰⡿⣻⠇⠀⠀⠀⠀⠀⣠⣶⣶⣶⣶⣿⣿⡿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
//⢐⣯⠞⠁⠀⠀⠀⠀⠀⠀⣄⠱⣄⠀⠀⠀⠀⠸⡧⠟⠆⠀⠀⠀⠀⠘⠿⢿⠿⠿⣿⡿⣿⠃⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
//⡾⠃⠀⠀⠀⠀⠀⠀⠀⠀⠘⢦⡈⠂⠀⠑⢄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢠⣿⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠒⡄⠀⠀⠑⠄⠀⠀⠀⠀⠀⠀⠀⢀⣠⣤⣦⣦⣼⡏⠳⣜⢿⠻⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠀⠀⠀⢠⣷⣦⣤⣀⣀⣀⣴⣿⣿⣿⣿⣿⡿⠻⠆⠸⣎⣧⠀⠈⠙⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿
//⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣄⠀⠀⠀⣸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠁⣠⡄⠀⣿⢹⡇⢸⡀⠀⠈⠻⢿⣿⣿⣿⣿⣿⣿