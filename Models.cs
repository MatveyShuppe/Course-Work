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
        public string PaymentMethod { get; set; }
        
    }
    public class Visits
    {
        public int Id { get; set; }
        public int MembershipId { get; set; }
        public DateTime? VisitDate { get; set; }
    }
    public class Users
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
    }
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
    public class MembershipTypes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Duration { get; set; }
        public int? VisitsLimit { get; set; }
    }
    public class Clients
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? BirthDay { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string? Status { get; set; }
        public string? Note { get; set; }
    }
}
