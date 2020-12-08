using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandevuSistemi.Data;
using RandevuSistemi.Data.Entity;
using RandevuSistemi.Models;

namespace RandevuSistemi.Controllers
{
    public class AppointmentController : Controller
    {
        private ApplicationDbContext _dbContext;

        public AppointmentController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public JsonResult GetAppointments()
        {
            var model = _dbContext.Appoinments
                .Include(p => p.User).Select(x => new AppointmentViewModel()
                {
                    Id = x.Id,
                    Dentist = x.User.Name + " " + x.User.Surname,
                    PatientName = x.PatientName,
                    PatientSurname = x.PatientSurname,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Description = x.Description,
                    Color = x.User.Color,
                    UserId = x.UserId

                });
            return Json(model);
        }

        public JsonResult GetAppointmentsByDentist(string userId = "")
        {
            var user = userId;
            var model = _dbContext.Appoinments.Where(x => x.UserId == userId)
                .Include(x => x.User).Select(x => new AppointmentViewModel()
                {
                    Id = x.Id,
                    Dentist = x.User.Name + " " + x.User.Surname,
                    PatientName = x.PatientName,
                    PatientSurname = x.PatientSurname,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Description = x.Description,
                    Color = x.User.Color,
                    UserId = x.User.Id
                });

            return Json(model);
        }

        [HttpPost]
        public JsonResult AddOrUpdateAppointment(SaveAppointmentModel model)
        {
            if (model.Id == 0)
            {
                var appointment = new Appointment
                {
                    CreatedDate = DateTime.Now,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    PatientName = model.PatientName,
                    PatientSurname = model.PatientSurname,
                    Description = model.Description,
                    UserId = model.UserId
                };


                _dbContext.Add(appointment);
                _dbContext.SaveChanges();

            }
            else
            {
                var entity = _dbContext.Appoinments.SingleOrDefault(p => p.Id == model.Id);
                if (entity != null)
                {
                    entity.UpdatedDate = DateTime.Now;
                    entity.StartDate = model.StartDate;
                    entity.EndDate = model.EndDate;
                    entity.PatientName = model.PatientName;
                    entity.PatientSurname = model.PatientSurname;
                    entity.Description = model.Description;
                    entity.UserId = model.UserId;

                    _dbContext.Update(entity);
                }

                _dbContext.SaveChanges();
            }
            return Json("200");

        }


        public JsonResult DeleteAppointment(int id = 0)
        {
            var entity = _dbContext.Appoinments.SingleOrDefault(p => p.Id == id);
            if (entity != null)
            {
                _dbContext.Remove((object) entity);
                _dbContext.SaveChanges();
                return Json("200");
            }
            else
            {
                return Json("404");
            }
            
        }
    }
}
