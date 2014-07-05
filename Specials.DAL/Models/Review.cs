using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public int SpecialId { get; set; }

        [Required]
        [ForeignKey("SpecialId")]
        public virtual Special Special { get; set; }
        public bool IsPublic { get; set; }
    }
}
