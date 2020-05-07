using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeDirectory.Models;

namespace EmployeeDirectory.Database
{
    public class EmployeeDbContext : DbContext 
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Employees.db");
            base.OnConfiguring(optionsBuilder);
        }
    }

    public static class InitializeDb
    {
        public static void Initize()
        {
            using (var db = new EmployeeDbContext())
            {
                db.Database.Migrate();
            }

            //using (var db = new EmployeeDbContext())
            //{
            //    db.Employees.Add(new Employee()
            //    {
            //        Id = 4,
            //        FirstName = "fdf"
            //    });
            //    db.SaveChanges();
            //}

            using (var db = new EmployeeDbContext())
            {
               var s =   db.Employees.ToList();
            }
        }
    }
}
