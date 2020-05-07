using EmployeeDirectory.Models;
using SQLite.CodeFirst;
using System.Data.Entity;

namespace EmployeeDirectory.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext() : base("SqliteDatabase")
        {

        }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<EmployeeDbContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);

        }
    }
}