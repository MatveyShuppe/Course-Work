using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corse_Project
{
    public class Membership
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int TypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? TotalVisits { get; set; }
        public int? RemainingVisits { get; set; }
        public string? Status { get; set; }
    }
}
