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
                .ForMember(dest => dest.AverageReviewScore, opt => opt.MapFrom(src => (GetAverage(src))))
                .ForMember(dest => dest.TotalReviews, opt => opt.MapFrom(src => src.Reviews.Count()))
                .ForMember(dest => dest.DayOfWeek, opt=>opt.MapFrom(src=> Enum.GetName(typeof(DayOfWeek), src.DayOfWeek)));
            Mapper.CreateMap<Tag, TagVM>();
            Mapper.CreateMap<Place, PlaceVM>();
            Mapper.CreateMap<Review, ReviewVM>();

            Mapper.AssertConfigurationIsValid();
        }

        private static string GetDayEnum(DayOfWeek day)
        {
            switch (day)
            {
                case (DayOfWeek.Monday):
                    return "Monday";
                case (DayOfWeek.Tuesday):
                    return "Tuesday";
                case (DayOfWeek.Wednesday):
                    return "Wednesday";
                case (DayOfWeek.Thursday):
                    return "Thursasdfay";
                case (DayOfWeek.Friday):
                    return "Friday";
                case (DayOfWeek.Saturday):
                    return "Saturday";
                default:
                    return "Sunday";
            }
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