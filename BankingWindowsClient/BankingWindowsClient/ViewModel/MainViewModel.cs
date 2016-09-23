using BankingWindowsClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;

namespace BankingWindowsClient.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
        }

        //private BaseViewModel _viewModel;

        //public BaseViewModel ViewModel
        //{
        //    get { return _viewModel; }
        //    set { _viewModel = value; RaisePropertyChangedEvent("ViewModel"); }
        //}

        public BaseViewModel ViewModel
        {
            get { return (BaseViewModel)_viewModel; }
            set { _viewModel = value; RaisePropertyChangedEvent("ViewModel"); }
        }

        public ICommand DisplayBankTasksView
        {
            get
            {
                return new RelayCommand(action => ViewModel = new BankTasksViewModel(), canExecute => !IsViewModelOfType<BankTasks>());
            }
        }

        //public ICommand DisplayBankTasksView
        //{
        //    get
        //    {
        //        return new RelayCommand(action => MainViewModel.ViewModel = new Window1ViewModel(), canExecute => !IsViewModelOfType<BankTasks>());
        //    }
        //}

        public ICommand DisplayUserTasksView
        {
            get
            {
                return new RelayCommand(action => ViewModel = new UserTasksViewModel(), canExecute => !IsViewModelOfType<UserTasks>());
            }
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




