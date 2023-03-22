using System.ComponentModel.DataAnnotations;

namespace arfan.Models.Dto.User
{
    public class UserCreateDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime Birth { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public string IdGoogle { get; set; }
    }
}
