using System.ComponentModel.DataAnnotations;

namespace TotallyNotADatingApp.DTO
{
    public class RegistrationDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(25, 
            ErrorMessage = "You can't have a password that is longer than 25 characters!!")]
        public string Password { get; set; }
    }
}