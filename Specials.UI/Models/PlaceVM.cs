using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Specials.UI.Models
{
    public class PlaceVM
    {
        public int PlaceId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}