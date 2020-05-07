using EmployeeDirectory.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Sqlite
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly EmployeeDbContext Db;
        public EmployeeRepository()
        {
            Db = new EmployeeDbContext();
        }
        public void Add(Employee entity)
        {
            Db.Employees.Add(entity);
        }

        public void Change(Employee newEntity)
        {
            Db.Employees.AddOrUpdate(newEntity);
        }

        public IEnumerable<Employee> GetAll()
        {
            return Db.Employees;
        }

        public Employee GetById(int id)
        {
            return Db.Employees.Find(id);
        }

        public void Remove(int id)
        {
            Db.Employees.Remove(Db.Employees.Find(id));
        }

        public void SaveChanges()
        {
            Db.SaveChanges();
        }
    }
}
