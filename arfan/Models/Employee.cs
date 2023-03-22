using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace arfan.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //----------PROFILE FOREIGN KEY---------
        public int? ProfileRefId { get; set; }
        [ForeignKey("ProfileRefId")]
        public Profile Profile { get; set; }
        //--------------------------------------
        public ICollection<Reserve> Reserve { get; set; }
        public ICollection<RelServicesEmployee> RelServicesEmployee { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
