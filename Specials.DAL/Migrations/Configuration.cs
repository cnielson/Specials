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
            //AddWingsTagsToSpecials(context);
        }

        private void AddWingsTagsToSpecials(SpecialsContext context)
        {
            var sps = context.Specials.ToList();
            var ts = context.Tags.Where(t=>t.TagId == 1 || t.TagId == 2);
            foreach(var sp in sps)
            {
                sp.Tags = ts.ToList();
            }
            context.SaveChanges();
        }

        private void AddSpecials(SpecialsContext context)
        {
            AddSpecial(context, 1, "$0.35 wings", "Mullen's", true, DayOfWeek.Monday);
            AddSpecial(context, 2, "$0.45 wings", "Bird's Nest", true, DayOfWeek.Sunday);
            AddSpecial(context, 3, "$0.45 wings", "Bird's Nest", true, DayOfWeek.Thursday);
            AddSpecial(context, 4, "$0.50 wings", "Racine Plumbing", true, DayOfWeek.Tuesday);
            AddSpecial(context, 5, "$0.35 wings", "Dark Horse", true, DayOfWeek.Thursday);
            AddSpecial(context, 6, "$0.40 wings", "Lincoln Station", true, DayOfWeek.Monday);
            AddSpecial(context, 7, "$0.30 wings", "Merkle's", true, DayOfWeek.Wednesday);
            AddSpecial(context, 8, "$6.00 jumbo wings(8)", "Mystic Celt", true, DayOfWeek.Wednesday);
            AddSpecial(context, 9, "$6.00 jumbo wings(8)", "Mystic Celt", true, DayOfWeek.Saturday);
            AddSpecial(context, 10, "$0.25 wings", "Kelly's Pub", true, DayOfWeek.Wednesday);
            AddSpecial(context, 11, "0.35 wings", "Houndstooth Saloon", true, DayOfWeek.Monday);
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
            context.SaveChanges();
        }

        private void AddSpecial(SpecialsContext context, int id, string name, string placeName, bool isValid, DayOfWeek dayOfWeek)
        {
            var place = context.Places.First(p => p.Name == placeName);
            var day = (int)dayOfWeek;
            if (place != null && day > 0 && day <= 7)
            {
                context.Specials.AddOrUpdate(new Special { SpecialId = id, Name = name, Place = place, IsValid = isValid, DayOfWeek = day });
            }
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