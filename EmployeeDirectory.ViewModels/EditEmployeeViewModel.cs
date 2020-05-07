using EmployeeDirectory.Sqlite;
using EmployeeDirectory.Models;
using GenericMVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.ViewModels
{
    public class EditEmployeeViewModel : EmployeeViewModel
    {
        private readonly int employeeId;
        public EditEmployeeViewModel(IRepository<Employee> repository,
                                      IEventAggregator aggregator, int EmployeeIDtoEdit)
            :base(repository, aggregator)
        {
            employeeId = EmployeeIDtoEdit;
            Employee employee = repository.GetById(employeeId);
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            Age = employee.Age;
            EmailAddress = employee.EmailAddress;
        }
        protected override void Accept()
        {
            var employee = repository.GetById(employeeId);
            employee.FirstName = FirstName;
            employee.LastName = LastName;
            employee.Age = Age;
            employee.EmailAddress = EmailAddress;

            repository.Change(employee);
            repository.SaveChanges();
            aggregator.Publish(new SwitchToVm(typeof(MainViewModel)));
        }

        protected override void Cancel()
        {
            aggregator.Publish(new SwitchToVm(typeof(MainViewModel)));
        }
    }
}
