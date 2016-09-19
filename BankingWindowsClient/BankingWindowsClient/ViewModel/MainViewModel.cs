using BankingWindowsClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingWindowsClient.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            Main = new Main();
        }

        public Main Main {get;set;}



    }
}
