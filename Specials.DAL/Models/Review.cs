using System.ComponentModel.DataAnnotations;

namespace Specials.DAL.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(0, 5, ErrorMessage = "Max value is 5")]
        public int Rating { get; set; }
        [Required]
        public virtual Special Special { get; set; }
        public bool IsPublic { get; set; }
    }
}
