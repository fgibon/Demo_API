using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace arfan.Models
{
    public class RelServicesEmployee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //----------SERVICES FOREIGN KEY---------
        public int ServiceRefId { get; set; }
        [ForeignKey("ServiceRefId")]
        public Service Service { get; set; }
        //----------EMPLOYEE FOREIGN KEY---------
        public int EmployeeRefId { get; set; }
        [ForeignKey("EmployeeRefId")]
        public Employee Employee { get; set; }
        //--------------------------------------
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
