using System.ComponentModel.DataAnnotations;

namespace arfan.Models.Dto.Reserve
{
    public class ReserveCreateDTO
    {
        //----------USERS FOREIGN KEY------------
        [Required]
        public int UserRefId { get; set; }
        //----------EMPLOYEE FOREIGN KEY---------
        [Required]
        public int EmployeeRefId { get; set; }
        //----------SERVICE FOREIGN KEY---------
        [Required]
        public int ServiceRefId { get; set; }
        //---------------------------------------
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
    }
}
