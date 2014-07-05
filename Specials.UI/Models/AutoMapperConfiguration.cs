using Specials.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Web;

namespace Specials.UI.Models
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Special, SpecialVM>()
                .ForMember(dest => dest.DayOfWeek, opt => opt.MapFrom(src => (DayOfWeek)src.DayOfWeek))
                .ForMember(dest => dest.AverageReviewScore, opt => opt.MapFrom(src => (GetAverage(src))))
                .ForMember(dest=>dest.TotalReviews, opt=>opt.MapFrom(src=>src.Reviews.Count()));
            Mapper.CreateMap<Tag, TagVM>();
            Mapper.CreateMap<Place, PlaceVM>();
            Mapper.CreateMap<Review, ReviewVM>();

            Mapper.AssertConfigurationIsValid();
        }

        private static int GetAverage(Special src)
        {
            if (src.Reviews.Any())
            {
                return src.Reviews.Sum(r => r.Rating) / src.Reviews.Count();
            }
            return -1;
        }
    }
}