using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Data
{
    public interface IRepository<T>
    {
        T GetById(int id);

        void Change(T newEntity);

        void Add(T entity);

        void Remove(int id);

        IEnumerable<T> GetAll();

        void SaveChanges();
    }
}
