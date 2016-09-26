using BankingWindowsClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankingWindowsClient.ViewModel
{
    class PersonViewModel : BaseViewModel
    {
        public PersonViewModel()
        {
            this.Model = new Person();

            GetPerson = new AsyncCommand(async () =>
            {
                await ((Person)Model).ReadPerson();
            });

            PostPerson = new AsyncCommand(async () =>
            {
                await ((Person)Model).CreatePerson();
            });

            PutPerson = new AsyncCommand(async () =>
            {
                await ((Person)Model).UpdatePerson();
            });

            DeletePerson = new AsyncCommand(async () =>
            {
                await ((Person)Model).DeletePerson();
            });
        }
        public AsyncCommand GetPerson { get; private set; }

        public AsyncCommand PostPerson { get; private set; }

        public AsyncCommand PutPerson { get; private set; }

        public AsyncCommand DeletePerson { get; private set; }
    }
}
