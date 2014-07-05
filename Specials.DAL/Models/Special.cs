using Specials.DAL.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Specials.DAL.Models
{
    public class Special
    {
        public Special()
        {
            Tags = new HashSet<Tag>();
            Reviews = new List<Review>();
        }
        [Key]
        public int SpecialId { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

        public int PlaceId { get; set; }

        [Required]
        [ForeignKey("PlaceId")]
        public virtual Place Place { get; set; }
        
        public virtual ICollection<Review> Reviews { get; set; }
        public bool IsValid { get; set; }
        [Range(0, 6, ErrorMessage = "must be from 0 - 6")]
        public int DayOfWeek { get; set; }
    }
}
