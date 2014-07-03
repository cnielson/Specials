using System.Data.Entity;

namespace Specials.DAL
{
    public class SpecialsDatabaseInitializer : DropCreateDatabaseIfModelChanges<SpecialsContext>
    {
        protected override void Seed(SpecialsContext context)
        {
        }
    }
}
