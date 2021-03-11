using System.ComponentModel.DataAnnotations;

namespace BitBoard.Business.Views.Account.Dtos
{
    public class LoginDto
    {
        [Required] 
        public string Username { get; set; }
        [Required] 
        public string Password { get; set; }
    }
}