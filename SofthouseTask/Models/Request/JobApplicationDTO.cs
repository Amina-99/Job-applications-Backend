using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SofthouseTask.Models.Request
{
    public class JobApplicationDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("[-s./0-9]*")]
        public string Phone { get; set; }
        [Required]
        public IFormFile CV { get; set; }
    }
}
