using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BankingWebAPI2.Models;
using System.Collections.ObjectModel;

namespace BankingWindowsClient.Model
{
    class Person : BaseModel<BankingWebAPI2.Models.Person>
    {
        #region Constructors
        public Person()
        {
            Controler = "api/People";
            WebRequest = new Tools.WebApi<Person, BankingWebAPI2.Models.Person>(this);
            this.Accounts = new ObservableCollection<Account>();
            this.Transactions = new ObservableCollection<Transaction>();
        }

        #endregion //Constructors

        #region Members
        private Tools.WebApi<Person, BankingWebAPI2.Models.Person> WebRequest;
        #endregion //Members

        #region Properties

        private long _id;
        public override long Id { get { return this._id; } set { this._id = value; RaisePropertyChangedEvent("Id"); } }

        private string _firstName;
        public string FirstName { get { return this._firstName; } set { this._firstName = value; RaisePropertyChangedEvent("FirstName"); } }

        private string _lastName;
        public string LastName { get { return this._lastName; } set { this._lastName = value; RaisePropertyChangedEvent("LastName"); } }

        private string _idNumber;
        public string IdNumber { get { return this._idNumber; } set { this._idNumber = value; RaisePropertyChangedEvent("IdNumber"); } }

        private Nullable<long> _eUserId;
        public Nullable<long> eUserId { get { return this._eUserId; } set { this._eUserId = value; RaisePropertyChangedEvent("eUserId"); } }

        private eUser _eUser;
        public eUser eUser { get { return this._eUser; } set { this._eUser = value; RaisePropertyChangedEvent("eUser"); } }

        public ObservableCollection<Account> Accounts { get;set;}

        public ObservableCollection<Transaction> Transactions { get; set; }

        #endregion //Properties

        #region CRUD
        public async Task CreatePerson()
        {
            WebRequest.Create();
        }

        public async Task ReadPerson()
        {
            WebRequest.Read();
        }

        public async Task UpdatePerson()
        {
            WebRequest.Update();
        }

        public async Task DeletePerson()
        {

            WebRequest.Delete();
        }
        #endregion //CRUD

        #region Convertion Methods
        public override BankingWebAPI2.Models.Person ToWebApiModel()
        {
            return new BankingWebAPI2.Models.Person()
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                IdNumber = this.IdNumber,
                eUser = this.eUser.ToWebApiModel(),
                Accounts = ObservableToCollection(this.Accounts, new List<BankingWebAPI2.Models.Account>()),
                Transactions = ObservableToCollection(this.Transactions, new List<BankingWebAPI2.Models.Transaction>()),
            };
        }

        
        

        public override void FromWebApiModel(BankingWebAPI2.Models.Person person)
        { 
            this.Id = person.Id;
            this.FirstName = person.FirstName;
            this.LastName = person.LastName;
            this.IdNumber = person.IdNumber;
            this.eUser.FromWebApiModel(person.eUser);

            CollectionToObservable(this.Accounts, person.Accounts);
            CollectionToObservable(this.Transactions, person.Transactions);
        }
        #endregion //Convertion Methods
    }


}
