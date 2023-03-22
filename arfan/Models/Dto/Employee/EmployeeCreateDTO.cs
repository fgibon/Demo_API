using System.ComponentModel.DataAnnotations;

namespace arfan.Models.Dto.Employee
{
    public class EmployeeCreateDTO
    {
        //----------PROFILE FOREIGN KEY---------
        public int? ProfileRefId { get; set; }
        //--------------------------------------
        [Required]
        public string Username { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
