using Specials.DAL.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Specials.DAL
{
    public class Special
    {
        public Special()
        {
            Reviews = new List<Review>();
        }
        [Key]
        public int SpecialId { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        [Required]
        public virtual Place Place { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public bool IsValid { get; set; }
    }
}
