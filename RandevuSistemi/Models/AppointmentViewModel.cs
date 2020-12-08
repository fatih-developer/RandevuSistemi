using System;

namespace RandevuSistemi.Models
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public string Dentist { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string Color { get; set; }
    }
}