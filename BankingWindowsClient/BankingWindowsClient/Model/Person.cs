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
            this.eUsers = new ObservableCollection<eUser>();
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

        public ObservableCollection<Account> Accounts { get;set;}

        public ObservableCollection<Transaction> Transactions { get; set; }

        public ObservableCollection<eUser> eUsers { get; set; }

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
            return new BankingWebAPI2.Models.Person() { Id = this.Id, FirstName = this.FirstName, LastName = this.LastName, IdNumber = this.IdNumber };
        }

        public override void FromWebApiModel(BankingWebAPI2.Models.Person person)
        { 
            this.Id = person.Id;
            this.FirstName = person.FirstName;
            this.LastName = person.LastName;
            this.IdNumber = person.IdNumber;

            this.Accounts.Clear();
            if (person.Accounts != null)
            {
                foreach (BankingWebAPI2.Models.Account account in person.Accounts)
                {
                    Account Converter = new Account();
                    Converter.FromWebApiModel(account);
                    this.Accounts.Add(Converter);
                }
            }

            this.Transactions.Clear();
            if (person.Transactions != null)
            {
                foreach (BankingWebAPI2.Models.Transaction transaction in person.Transactions)
                {
                    Transaction Converter = new Transaction();
                    Converter.FromWebApiModel(transaction);
                    this.Transactions.Add(Converter);
                }
            }

            this.eUsers.Clear();
            if (person.eUsers != null)
            {                
                foreach (BankingWebAPI2.Models.eUser eUser in person.eUsers)
                {
                    eUser Converter = new eUser();
                    Converter.FromWebApiModel(eUser);
                    this.eUsers.Add(Converter);
                }
            }


        }
        #endregion //Convertion Methods
    }


}
