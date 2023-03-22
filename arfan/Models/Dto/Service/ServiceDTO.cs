using System.ComponentModel.DataAnnotations;

namespace arfan.Models.Dto.Service
{
    public class ServiceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime AssignedTime { get; set; }
    }
}
