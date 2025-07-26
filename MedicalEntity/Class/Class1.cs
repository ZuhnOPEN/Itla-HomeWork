using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace EntityProyect.Class
{
    public class user
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cedula {  get; set; }
        public string Email { get; set; }
        public string lastName { get; set; }
        public string Numero { get; set; }

    }

    public class userContext : DbContext
    {
        public DbSet<user> users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = Contacts; Trusted_Connection = True; ");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
