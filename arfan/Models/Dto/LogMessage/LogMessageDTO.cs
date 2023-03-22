using System.ComponentModel.DataAnnotations;

namespace arfan.Models.Dto.LogMessageDTO
{
    public class LogMessageDTO
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Message { get; set; }
    }
}


