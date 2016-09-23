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
            Main = new Main();
        }

        public Main Main {get;set;}

        public ICommand DisplayBankTasksView
        {
            get
            {
                return new RelayCommand(action => ViewModel = new BankTasksViewModel(), canExecute => !IsViewModelOfType<BankTasks>());
            }
        }

    }
}




