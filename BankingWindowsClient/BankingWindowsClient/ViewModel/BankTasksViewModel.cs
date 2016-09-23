using BankingWindowsClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingWindowsClient.ViewModel
{
    class BankTasksViewModel: BaseViewModel
    {
        public BankTasksViewModel()
        {
            BankTask = new BankTasks();
        }

        BankTasks BankTask { get; set; }
    }
}
