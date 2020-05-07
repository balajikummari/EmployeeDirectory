using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SQLite.EF6.Migrations;
using System.Text;
using System.Threading.Tasks;
using EmployeeDirectory.Models;

namespace EmployeeDirectory.Sqlite
{
    public class EmployeeDbContext : DbContext 
    {
        public DbSet<Employee> Employees { get; set; }
        public EmployeeDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EmployeeDbContext, ContextMigrationConfiguration>(true));
        }

        internal sealed class ContextMigrationConfiguration : DbMigrationsConfiguration<EmployeeDbContext>
        {
            public ContextMigrationConfiguration()
            {
                AutomaticMigrationsEnabled = true;
                AutomaticMigrationDataLossAllowed = true;
                SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());
            }
        }

    }
}
