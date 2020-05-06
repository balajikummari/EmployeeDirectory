using GenericMVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.ViewModels
{
    public class ShellViewModel : IHandle<SwitchToVm>, INotifyPropertyChanged
    {
        public ShellViewModel(IEventAggregator aggregator)
        {
            aggregator.Subscribe(this);
            CurrentViewModel = IoC.Get<MainViewModel>();
        }

        private object currentViewModel;

        public object CurrentViewModel
        {
            get { return currentViewModel; }
            private set { currentViewModel = value; OnPropertyChanged(); }
        }
        public void Handle(SwitchToVm message)
        {
            CurrentViewModel = IoC.Get(message.ViewModel);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
