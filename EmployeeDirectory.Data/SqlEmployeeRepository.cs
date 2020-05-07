using EmployeeDirectory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Data
{
    public class SqlEmployeeRepository : IRepository<Employee>
    {
        private EmployeeDbContext Db;
        public SqlEmployeeRepository()
        {
            Db = new EmployeeDbContext();
        }
        public void Add(Employee entity)
        {
            Db.Employees.Add(entity);
        }

        public void Change(Employee newEntity)
        {
           var ActualData = Db.Employees.Find(newEntity.Id) ;
           ActualData = newEntity;
            Db.SaveChanges();
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
