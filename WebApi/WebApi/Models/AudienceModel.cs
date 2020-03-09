using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class AudienceModel
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
    }
}