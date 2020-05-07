using System.Data.Entity;
using SQLite.CodeFirst;

namespace EmployeeDirectory.DataAcess
{
    public class FootballDbInitializer : SqliteDropCreateDatabaseWhenModelChanges<FootballDbContext>
    {
        public FootballDbInitializer(DbModelBuilder modelBuilder)
            : base(modelBuilder, typeof(CustomHistory))
        { }

        protected override void Seed(FootballDbContext context)
        {
            // Here you can seed your core data if you have any.
        }
    }
}