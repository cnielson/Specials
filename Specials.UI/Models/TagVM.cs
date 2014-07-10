using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Specials.UI.Models
{
    public class TagVM
    {
        [Key]
        public int TagId { get; set; }

        [Required]
        [Display(Name = "Tags")]
        public string Name { get; set; }
    }
}