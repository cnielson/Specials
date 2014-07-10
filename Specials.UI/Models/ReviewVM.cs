using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Specials.UI.Models
{
    public class ReviewVM
    {
        [Key]
        public int ReviewId { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(0, 5, ErrorMessage = "Max value is 5")]
        public int Rating { get; set; }
        [Required]
        public bool IsPublic { get; set; }
    }
}