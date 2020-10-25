using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models.DTOs
{
    public class RegisterDto : UserDto
    {
        [Required] 
        public string Password { get; set; }
    }
}