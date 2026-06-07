using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corse_Project
{
    public class MembershipTypes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Duration { get; set; }
        public int? VisitsLimit { get; set; }
    }
}
