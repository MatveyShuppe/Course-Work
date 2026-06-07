using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corse_Project
{
    public class Clients
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string? Status { get; set; }
        public string? Note { get; set; }
    }
}
