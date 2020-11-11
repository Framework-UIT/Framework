using System.ComponentModel.DataAnnotations;

namespace Framework.Models
{
    public class RegisterModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string ToString()
        {
            string Field = Username + " " + Email + " " + Password;
            return Field;
        }

    }
}