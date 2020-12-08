using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace RandevuSistemi.Data.Entity
{
    public class AppUser : IdentityUser
    {
        public bool IsDentist { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Color { get; set; }

        public List<Appointment> Appoinments { get; set; }
    }
}