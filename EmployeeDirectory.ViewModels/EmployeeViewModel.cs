using EmployeeDirectory.Sqlite;
using EmployeeDirectory.Models;
using GenericMVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmployeeDirectory.ViewModels
{
    public abstract class EmployeeViewModel : INotifyPropertyChanged
    {
        protected readonly IRepository<Employee> repository;
        protected readonly IEventAggregator aggregator;
        private string firstName;
        private string lastName;
        private int age;
        private string emailAddress;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged();
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged();
            }
        }

        public string EmailAddress
        {
            get { return emailAddress; }
            set
            {
                emailAddress = value;
                OnPropertyChanged();
            }
        }

        public ICommand AcceptCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        protected EmployeeViewModel(IRepository<Employee> repository, IEventAggregator aggregator)
        {
            this.repository = repository;
            this.aggregator = aggregator;
            AcceptCommand = new RelayCommand(Accept);
            CancelCommand = new RelayCommand(Cancel);
        }

        protected abstract void Accept();
        protected abstract void Cancel();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
