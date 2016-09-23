using BankingWindowsClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace BankingWindowsClient.ViewModel
{
    class BankTasksViewModel: BaseViewModel
    {

        public BankTasksViewModel()
        {
            this.Model = new Model.BankTasks();
        }

        public BaseViewModel ViewModel
        {
            get { return (BaseViewModel)_viewModel; }
            set { _viewModel = value; RaisePropertyChangedEvent("ViewModel"); }
        }

        public ICommand DisplayPersonView
        {
            get
            {
                return new RelayCommand(action => ViewModel = new PersonViewModel(), canExecute => !IsViewModelOfType<Person>());
            }
        }


    }
}
