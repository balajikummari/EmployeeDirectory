using EmployeeDirectory.Sqlite;
using EmployeeDirectory.Models;
using GenericMVVM;


namespace EmployeeDirectory.ViewModels
{
    public class AddEmployeeViewModel : EmployeeViewModel
    {
        public AddEmployeeViewModel(IRepository<Employee> provider,
                                   IEventAggregator aggregator) : base(provider, aggregator) { }

        protected override void Accept()
        {
            var Employee = new Employee
            {
                FirstName = FirstName,
                LastName = LastName,
                Age = Age,
                EmailAddress = EmailAddress
            };
            repository.Add(Employee);
            repository.SaveChanges();

            aggregator.Publish(new SwitchToVm(typeof(MainViewModel)));
        }

        protected override void Cancel()
        {
            aggregator.Publish(new SwitchToVm(typeof(MainViewModel)));
        }
    }
}
