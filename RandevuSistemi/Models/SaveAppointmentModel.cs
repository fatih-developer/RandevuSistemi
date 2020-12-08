using System;
using RandevuSistemi.Data.Entity;

namespace RandevuSistemi.Models
{
    public class SaveAppointmentModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string UserId { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string Description { get; set; }
    }
}