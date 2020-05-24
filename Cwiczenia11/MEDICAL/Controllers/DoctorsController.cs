using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using MEDICAL.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using Wyklad10Sample.Models;

namespace MEDICAL.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {

        private readonly s19299DbContext dbContext;

        DoctorsController(s19299DbContext context)
        {

            this.dbContext = context;

        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(dbContext.Doctor.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetDoctors(int id)
        {
            return Ok(dbContext.Doctor.ToList().Find(d => d.IdDoctor == id));
        }

        [HttpPut("update")]
        public IActionResult UpdateDoctorInformation(UpdateDoctorRequest request)
        {
            try
            {
                var doctor = dbContext.Doctor.ToList().Find(d => d.IdDoctor == request.idDoctor);

                if (doctor != null)
                {
                    if (request.Prescription != null)
                    {
                        doctor.Prescription = request.Prescription;
                    }

                    if (request.Email != null)
                    {
                        doctor.Email = request.Email;
                    }

                    if (request.FirstName != null)
                    {
                        doctor.FirstName = request.FirstName;
                    }

                    if (request.LastName != null)
                    {
                        doctor.LastName = request.LastName;
                    }

                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            return Ok("doctor's informations with id:" + request.idDoctor + " have been updated");
        }

        [HttpPost]
        public IActionResult AddDoctor(Doctor doctor)
        {
            if (doctor == null)
            {
                return NoContent();
            }
            dbContext.Doctor.Add(doctor);
            dbContext.SaveChanges();
            return Ok("doctor has been added");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            dbContext.Doctor.ToList().Remove(dbContext.Doctor.ToList().Find(d => d.IdDoctor == id));
            dbContext.SaveChanges();
            return Ok("doctor has been removed");
        }

    }
}