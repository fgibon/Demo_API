using System.ComponentModel.DataAnnotations;

namespace arfan.Models.Dto.Service
{
    public class ServiceCreateDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime AssignedTime { get; set; }
    }
}
