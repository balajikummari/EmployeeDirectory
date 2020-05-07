using EmployeeDirectory.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.DataAccess
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext()
        {
          
        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Employee.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
