using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace arfan.Models
{
    public class Reserve
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //----------USERS FOREIGN KEY------------
        public int UserRefId { get; set; }
        [ForeignKey("UserRefId")]
        public User User { get; set; }
        //----------EMPLOYEE FOREIGN KEY---------
        public int EmployeeRefId { get; set; }
        [ForeignKey("EmployeeRefId")]
        public Employee Employee { get; set; }
        //----------SERVICE FOREIGN KEY---------
        public int ServiceRefId { get; set; }
        [ForeignKey("ServiceRefId")]
        public Service Service { get; set; }
        //---------------------------------------
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
