using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.DataAcess
{
    public class conect
    {
        public conect()
        {
            using (var sqLiteConnection = new SqliteConnection("data source=:memory:"))
            {
                // This is required if a in memory db is used.
                sqLiteConnection.Open();

                using (var context = new FootballDbContext(sqLiteConnection, false))
                {
                    context.Employees.Add(new Models.Employee()
                    {
                        Id = 4
                    });
                }
            }
        }
    }
}
