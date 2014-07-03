namespace Specials.DAL.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Specials.DAL.SpecialsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Specials.DAL.SpecialsContext context)
        {
        }
    }
}
