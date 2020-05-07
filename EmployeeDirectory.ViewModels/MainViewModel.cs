using EmployeeDirectory.DataAccess;
using EmployeeDirectory.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using System.Windows.Input;
using GenericMVVM;
using System.Configuration;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EmployeeDirectory.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged 
    {
    
        private IRepository<Employee> employeeRepository;
        private ObservableCollection<Employee> employeeList;
        public ObservableCollection<Employee> EmployeeList {
            get { return employeeList; }
            private set { employeeList = value; OnPropertyChanged(); } }

     
        private readonly IEventAggregator aggregator;


        #region Commands
        private ICommand addEmployeeCommand;
        private ICommand removeCommand;
        private ICommand editEmployeeCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddEmployeeCommand
        { get { return addEmployeeCommand;  } }

        public ICommand EditEmployeeCommand
        { get { return editEmployeeCommand; } }

        public ICommand RemoveCommand
            { get { return removeCommand; } }
        #endregion

        public Employee SelectedEmployee { get; set; }

        public MainViewModel(IRepository<Employee> repository, IEventAggregator aggregator)
        {
            employeeRepository = repository;
            this.aggregator = aggregator;
           
            addEmployeeCommand = new RelayCommand(AddEmployee);
            editEmployeeCommand = new RelayCommand(EditEmployee, IsSelected);
            removeCommand = new RelayCommand(Remove, IsSelected);
        }

        private void Remove()
        {
            employeeRepository.Remove(SelectedEmployee.Id);
            employeeRepository.SaveChanges();
            ReloadList();
        }


        private void ReloadList()
        {
            var employees = employeeRepository.GetAll().ToList();
            EmployeeList = new ObservableCollection<Employee>(employees);
        }

        private bool IsSelected()
        {
            return SelectedEmployee != null;
        }
        public void OnViewLoaded()  // Attached Behaviour
        {
           ReloadList();
        }

        #region CommandHandlers
        private void EditEmployee()
        {
            ConfigurationManager.AppSettings.Set("EmployeeIDtoEdit", SelectedEmployee.Id.ToString());
            aggregator.Publish(new SwitchToVm(typeof(EditEmployeeViewModel)));
        }

        private void AddEmployee()
        {
            aggregator.Publish(new SwitchToVm(typeof(AddEmployeeViewModel)));
        }
        #endregion

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
