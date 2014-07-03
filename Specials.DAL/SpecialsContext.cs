using Specials.DAL.Models;
using System.Data.Entity;

namespace Specials.DAL
{
    public class SpecialsContext : DbContext
    {
        public SpecialsContext() : base("DefaultConnection") { }

        public static SpecialsContext Create()
        {
            return new SpecialsContext();
        }

        public DbSet<Special> Specials { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
