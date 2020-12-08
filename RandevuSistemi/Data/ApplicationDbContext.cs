using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RandevuSistemi.Data.Entity;

namespace RandevuSistemi.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser,AppRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Appointment> Appoinments { get; set; }

    }
}
