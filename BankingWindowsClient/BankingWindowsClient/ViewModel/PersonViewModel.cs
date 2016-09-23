using BankingWindowsClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingWindowsClient.ViewModel
{
    class PersonViewModel : BaseViewModel
    {
        public PersonViewModel()
        {
            this.Model = new Person();
        }
    }
}
