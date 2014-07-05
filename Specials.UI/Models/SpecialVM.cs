using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Specials.UI.Models
{
    public class SpecialVM
    {
        public int SpecialId { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<TagVM> Tags { get; set; }
        [Required]
        public PlaceVM Place { get; set; }
        public ICollection<ReviewVM> Reviews { get; set; }
        public bool IsValid { get; set; }
        [Required]
        [Display(Name="Day")]
        public DayOfWeek DayOfWeek { get; set; }
        [Display(Name="Average Review / 5")]
        public int AverageReviewScore { get; set; }
        public int TotalReviews { get; set; }
    }
}