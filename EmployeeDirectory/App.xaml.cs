using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using EmployeeDirectory.Sqlite;

namespace EmployeeDirectory.Views
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            using (var db = new EmployeeDbContext())
            {
                var s = db.Employees.ToList();
            }
            var bootstrapper = new Bootstrapper();
            bootstrapper.Start();
        }
    }
}
