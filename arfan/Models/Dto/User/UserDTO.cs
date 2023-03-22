using System.ComponentModel.DataAnnotations;

namespace arfan.Models.Dto.User
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public DateTime Birth { get; set; }
        public int PhoneNumber { get; set; }
        public string IdGoogle { get; set; }
    }
}
