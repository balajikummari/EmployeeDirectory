using System.Data.Common;
using System.Data.Entity;
using EmployeeDirectory.Models;

namespace EmployeeDirectory.DataAcess
{
    public class FootballDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public FootballDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Configure();
        }

        public FootballDbContext(DbConnection connection, bool contextOwnsConnection)
            : base(connection, contextOwnsConnection)
        {
            Configure();
        }

        private void Configure()
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ModelConfiguration.Configure(modelBuilder);
            var initializer = new FootballDbInitializer(modelBuilder);
            Database.SetInitializer(initializer);
        }
    }
}