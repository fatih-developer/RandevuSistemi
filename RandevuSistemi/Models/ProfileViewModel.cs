using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using RandevuSistemi.Data.Entity;

namespace RandevuSistemi.Models
{
    public class ProfileViewModel
    {
        public AppUser User { get; set; }
        public List<AppUser> Dentists { get; set; }
        public List<SelectListItem> DentistList { get; set; }
    }
}