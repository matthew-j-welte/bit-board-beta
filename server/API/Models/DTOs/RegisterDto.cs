using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models.DTOs
{
    public class RegisterDto
    {
        [Required] 
        [StringLength(40)]
        public string UserName { get; set; }

        [Required] 
        public string Password { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearsExperience { get; set; }
        public string CareerSummary { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}