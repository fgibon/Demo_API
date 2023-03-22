using System.ComponentModel.DataAnnotations;

namespace arfan.Models.Dto.Employee
{
    public class EmployeeUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        //----------PROFILE FOREIGN KEY---------
        [Required]
        public int ProfileRefId { get; set; }
        //--------------------------------------
        public string? Username { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Password { get; set; }
    }
}
