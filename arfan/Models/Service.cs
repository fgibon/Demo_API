using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace arfan.Models
{
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ICollection<Reserve> Reserve { get; set; }
        public ICollection<RelServicesEmployee> RelServicesEmployee { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime AssignedTime { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
