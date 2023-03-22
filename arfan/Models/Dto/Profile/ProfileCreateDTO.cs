using System.ComponentModel.DataAnnotations;

namespace arfan.Models.Dto.Profile
{
    public class ProfileCreateDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
