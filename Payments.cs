using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corse_Project
{
    public class Payments
    {
        public string Id { get; set; }
        public int ClientId { get; set; }
        public int MembershipId { get; set; }
        public int Amount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string PeymentMethod { get; set; }
    }
}
