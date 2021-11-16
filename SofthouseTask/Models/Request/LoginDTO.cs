using System.ComponentModel.DataAnnotations;

namespace SofthouseTask.Models.Request
{
    public class LoginDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
