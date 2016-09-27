using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingWindowsClient.Model
{
    class Account : BaseModel<BankingWebAPI2.Models.Account>
    {
        #region Constructors
        public Account()
        {
            Controler = "api/Accounts";
            WebRequest = new Tools.WebApi<Account, BankingWebAPI2.Models.Account>(this);

            this.Balances = new ObservableCollection<Balance>();
            this.Transactions = new ObservableCollection<Transaction>();
            this.People = new ObservableCollection<Person>();
        }

        #endregion //Constructors

        #region Members
        private Tools.WebApi<Account, BankingWebAPI2.Models.Account> WebRequest;
        #endregion //Members

        #region Properties

        private long _id;
        public override long Id { get { return this._id; } set { this._id = value; RaisePropertyChangedEvent("Id"); } }

        private string _description;
        public string Description { get { return this._description; } set { this._description = value; RaisePropertyChangedEvent("Description"); } }

        private Person _person;
        public Person Person { get { return this._person; } set { this._person = value; RaisePropertyChangedEvent("Person"); } }

        ObservableCollection<Balance> Balances { get; set; }

        ObservableCollection<Transaction> Transactions { get; set; }

        ObservableCollection<Person> People { get; set; }

        #endregion //Properties

        #region CRUD
        public async Task CreateAccount()
        {
            WebRequest.Create();
        }

        public async Task ReadAccount()
        {
            WebRequest.Read();
        }

        public async Task UpdateAccount()
        {
            WebRequest.Update();
        }

        public async Task DeleteAccount()
        {

            WebRequest.Delete();
        }
        #endregion //CRUD

        #region Convertion Methods
        public override BankingWebAPI2.Models.Account ToWebApiModel()
        {
            return new BankingWebAPI2.Models.Account() { Id = this.Id, Description = this.Description };
        }

        public override void FromWebApiModel(BankingWebAPI2.Models.Account Account)
        {
            this.Id = Account.Id;
            this.Description = Account.Description;

            CollectionToObservable(this.Balances, Account.Balances);
            CollectionToObservable(this.Transactions, Account.Transactions);
            CollectionToObservable(this.People, Account.People);
        }
        #endregion //Convertion Methods
    }
}
