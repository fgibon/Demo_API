using System.ComponentModel.DataAnnotations;

namespace arfan.Models.Dto.Profile
{
    public class ProfileUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
