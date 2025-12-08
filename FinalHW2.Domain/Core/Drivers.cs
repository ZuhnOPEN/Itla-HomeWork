using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalHW2.Domain.Core
{
    public class Drivers : BaseEntity
    {
        public int Id { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
