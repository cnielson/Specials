using System.Linq;

namespace Specials.DAL.Migrations
{
    using Specials.DAL.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<SpecialsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Specials.DAL.SpecialsContext context)
        {
            AddPlaces(context);
            AddTags(context);
            AddSpecials(context);
            AddWingsTagsToSpecials(context);
            AddReviews(context);
        }

        private void AddReviews(SpecialsContext context)
        {
            var rv = new Review { ReviewId = 1, IsPublic = true, Rating = 3, Description = "Solid wings. Cheesie buffalo was the best sauce but not really spicy. Their spiciest sauce was a little spicy but not much for flavor.", SpecialId = 1 };
            context.Reviews.AddOrUpdate(rv);
            context.SaveChanges();
        }

        private void AddWingsTagsToSpecials(SpecialsContext context)
        {
            var sps = context.Specials.ToList();
            var ts = context.Tags.Where(t => t.TagId == 1 || t.TagId == 2).ToList();
            foreach (var sp in sps)
            {
                foreach (var tag in ts)
                {
                    if (!sp.Tags.Any(t => t.TagId == tag.TagId))
                    {
                        sp.Tags.Add(tag);
                    }
                }
            }
            context.SaveChanges();
        }

        private void AddSpecials(SpecialsContext context)
        {
            AddSpecial(context, 1, "35¢ wings", "Mullen's", true, DayOfWeek.Monday);
            AddSpecial(context, 2, "45¢ wings", "Bird's Nest", true, DayOfWeek.Sunday);
            AddSpecial(context, 3, "45¢ wings", "Bird's Nest", true, DayOfWeek.Thursday);
            AddSpecial(context, 4, "50¢ wings", "Racine Plumbing", true, DayOfWeek.Tuesday);
            AddSpecial(context, 5, "35¢ wings", "Dark Horse", true, DayOfWeek.Thursday);
            AddSpecial(context, 6, "40¢ wings", "Lincoln Station", true, DayOfWeek.Monday);
            AddSpecial(context, 7, "30¢ wings", "Merkle's", true, DayOfWeek.Wednesday);
            AddSpecial(context, 8, "$6.00 jumbo wings (8)", "Mystic Celt", true, DayOfWeek.Wednesday);
            AddSpecial(context, 9, "$6.00 jumbo wings (8)", "Mystic Celt", true, DayOfWeek.Saturday);
            AddSpecial(context, 10, "25¢ wings", "Kelly's Pub", true, DayOfWeek.Wednesday);
            AddSpecial(context, 11, "35¢ wings", "Houndstooth Saloon", true, DayOfWeek.Monday);
            AddSpecial(context, 12, "50¢ wings", "McFadden's", true, DayOfWeek.Wednesday);
            AddSpecial(context, 13, "50¢ wings", "Avenue Tavern", true, DayOfWeek.Saturday);
            AddSpecial(context, 14, "$3.50 small order wings", "Toons", true, DayOfWeek.Thursday);
            AddSpecial(context, 15, "35¢ wings", "Temple Bar", true, DayOfWeek.Monday);
            AddSpecial(context, 16, "45¢ jumbo wings", "Patsy's Pub", true, DayOfWeek.Thursday);
            AddSpecial(context, 17, "50C wings", "Rocks Lakeview", true, DayOfWeek.Monday);
            AddSpecial(context, 18, "25¢ jumbo wings", "The Rail", true, DayOfWeek.Monday);
            AddSpecial(context, 19, "25¢ jumbo wings", "The Rail", true, DayOfWeek.Thursday);
            AddSpecial(context, 20, "40¢ wings", "O’Donovan’s", true, DayOfWeek.Tuesday);
            AddSpecial(context, 21, "$5 all you can eat wings", "Gannon's Pub", true, DayOfWeek.Wednesday);
            context.SaveChanges();
        }

        private void AddTags(SpecialsContext context)
        {
            AddTag(context, 1, "wing");
            AddTag(context, 2, "food");
            AddTag(context, 3, "beer");
            AddTag(context, 4, "wine");
            AddTag(context, 5, "drink");
            AddTag(context, 6, "bloody mary");
            AddTag(context, 7, "craft");
            AddTag(context, 8, "burger");
            AddTag(context, 9, "beer");
            context.SaveChanges();
        }

        private void AddPlaces(SpecialsContext context)
        {
            AddPlace(context, 1, "Bird's Nest");
            AddPlace(context, 2, "Buffalo Wild Wings");
            AddPlace(context, 3, "Mullen's");
            AddPlace(context, 4, "Racine Plumbing");
            AddPlace(context, 5, "Dark Horse");
            AddPlace(context, 6, "Lincoln Station");
            AddPlace(context, 7, "Merkle's");
            AddPlace(context, 8, "Mystic Celt");
            AddPlace(context, 9, "Kelly's Pub");
            AddPlace(context, 10, "Houndstooth Saloon");
            AddPlace(context, 11, "McFadden's");
            AddPlace(context, 12, "Avenue Tavern");
            AddPlace(context, 13, "Toons");
            AddPlace(context, 14, "Temple Bar");
            AddPlace(context, 15, "Patsy's Pub");
            AddPlace(context, 16, "Rocks Lakeview");
            AddPlace(context, 17, "The Rail");
            AddPlace(context, 18, "O’Donovan’s");
            AddPlace(context, 19, "Gannon's Pub");
            context.SaveChanges();
        }

        private void AddSpecial(SpecialsContext context, int id, string name, string placeName, bool isValid, DayOfWeek dayOfWeek)
        {
            var place = context.Places.First(p => p.Name == placeName);
            var day = (int)dayOfWeek;
            if (place != null)
            {
                var special = new Special { SpecialId = id, Name = name, PlaceId = place.PlaceId, IsValid = isValid, DayOfWeek = day };
                context.Specials.AddOrUpdate(new Special { SpecialId = id, Name = name, PlaceId = place.PlaceId, IsValid = isValid, DayOfWeek = day });
            }
            context.SaveChanges();
        }

        private void AddPlace(SpecialsContext context, int id, string name)
        {
            context.Places.AddOrUpdate(new Place { PlaceId = id, Name = name });
        }

        private void AddTag(SpecialsContext context, int id, string name)
        {
            context.Tags.AddOrUpdate(new Tag { TagId = id, Name = name });
        }
    }
}