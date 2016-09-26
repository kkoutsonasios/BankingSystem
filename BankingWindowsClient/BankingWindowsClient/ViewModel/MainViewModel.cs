using BankingWindowsClient.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            this.Model = new Main();

            ChangedView += MainViewModel_ChangedView;
        }

        private void MainViewModel_ChangedView(object sender, EventArgs e)
        {
            this.RaisePropertyChangedEvent("ViewModel");
        }

        public ICommand DisplayBankTasksView
        {
            get
            {
                return new RelayCommand(action => { ViewModel = new BankTasksViewModel(); }, canExecute => !IsViewModelOfType<BankTasks>());
            }
        }
        
        public ICommand DisplayUserTasksView
        {
            get
            {
                return new RelayCommand(action => { ViewModel = new UserTasksViewModel(); }, canExecute => !IsViewModelOfType<UserTasks>());
            }
        }

        public ICommand DisplayPersonView
        {
            get
            {
                return new RelayCommand(action => { ViewModel = new PersonViewModel(); }, canExecute => !IsViewModelOfType<Person>());
            }
        }
    }
}




