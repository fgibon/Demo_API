using System.ComponentModel.DataAnnotations;

namespace arfan.Models.Dto.RelServicesEmployee
{
    public class RelServicesEmployeeDTO
    {
        [Required]
        public int Id { get; set; }
        //----------SERVICES FOREIGN KEY---------
        [Required]
        public int ServiceRefId { get; set; }
        //----------EMPLOYEE FOREIGN KEY---------
        [Required]
        public int EmployeeRefId { get; set; }
        //--------------------------------------
    }
}
