using System.ComponentModel.DataAnnotations;

namespace arfan.Models.Dto.Reserve
{
    public class ReserveDTO
    {
        public int Id { get; set; }
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
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
