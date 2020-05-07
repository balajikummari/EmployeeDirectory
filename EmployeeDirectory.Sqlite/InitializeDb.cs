using System.Linq;
using EmployeeDirectory.Models;

namespace EmployeeDirectory.Sqlite
{
    public static class InitializeDb
    {
        public static void Initize()
        {
            using (var db = new EmployeeDbContext())
            {
               var s =   db.Employees.ToList();
            }
        }
    }
}
