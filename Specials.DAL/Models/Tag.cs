using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Specials.DAL.Models
{
    public class Tag
    {
        public Tag()
        {
            this.Specials = new HashSet<Special>();
        }

        [Key]
        public int TagId { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Special> Specials { get; set; }
    }
}
