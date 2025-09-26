using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comunity.Clases
{
    public class Comunity_Member
    {
        public string Name { get; set; }
        public string lastName { get; set; }
        public string Role {  get; set; }
        public string MemberId { get; set; }

        public static void info()
        {
            Comunity_Member member = new Comunity_Member();
            string name = member.Name = "Homer";
            string lname = member.lastName = "Simpson";
            string role = member.Role = "Father";
            string id = member.MemberId = "74253698";
            Console.WriteLine("Their name is: " + name + " His last name is: " + lname + " Role: " + role + " Member ID: " + id);
        }

    }
}
