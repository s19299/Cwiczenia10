using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wyklad10Sample.Models;

namespace MEDICAL.DTO
{
    public class UpdateDoctorRequest
    {
        [Required]
        public int idDoctor;
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
       
        public virtual ICollection<Prescription> Prescription { get; set; } 
        
    }
}