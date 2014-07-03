using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Specials.DAL.Models
{
    public class Place
    {
        public Place()
        {
            Specials = new List<Special>();
        }
        [Key]
        public int PlaceId { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Special> Specials { get; set; }
    }
}
