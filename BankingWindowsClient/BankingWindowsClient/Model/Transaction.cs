using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingWindowsClient.Model
{
    class Transaction : BaseModel<BankingWebAPI2.Models.Transaction>
    {
        #region Constructors
        public Transaction()
        {
            Controler = "api/Transactions";
            WebRequest = new Tools.WebApi<Transaction, BankingWebAPI2.Models.Transaction>(this);
        }

        #endregion //Constructors

        #region Members
        private Tools.WebApi<Transaction, BankingWebAPI2.Models.Transaction> WebRequest;
        #endregion //Members

        #region Properties

        private long _id;
        public override long Id { get { return this._id; } set { this._id = value; RaisePropertyChangedEvent("Id"); } }

        private double _amount;
        public double Amount { get { return this._amount; } set { this._amount = value; RaisePropertyChangedEvent("Amount"); } }

        private string _description;
        public string Description { get { return this._description; } set { this._description = value; RaisePropertyChangedEvent("Description"); } }

        private Nullable<long> _personId;
        public Nullable<long> PersonId { get { return this._personId; } set { this._personId = value; RaisePropertyChangedEvent("PersonId"); } }

        private Nullable<long> _accountId;
        public Nullable<long> AccountId { get { return this._accountId; } set { this._accountId = value; RaisePropertyChangedEvent("AccountId"); } }

        private bool _executed;
        public bool Executed { get { return this._executed; } set { this._executed = value; RaisePropertyChangedEvent("Executed"); } }

        private System.DateTime _creationDate;
        public System.DateTime CreationDate { get { return this._creationDate; } set { this._creationDate = value; RaisePropertyChangedEvent("CreationDate"); } }

        private System.DateTime _executionDate;
        public System.DateTime ExecutionDate { get { return this._executionDate; } set { this._executionDate = value; RaisePropertyChangedEvent("ExecutionDate"); } }

        private Account _account;
        public Account Account { get { return this._account; } set { this._account = value; RaisePropertyChangedEvent("Account"); } }

        private Person _person;
        public Person Person { get { return this._person; } set { this._person = value; RaisePropertyChangedEvent("Person"); } }

        #endregion //Properties

        #region CRUD
        public async Task CreateTransaction()
        {
            WebRequest.Create();
        }

        public async Task ReadTransaction()
        {
            WebRequest.Read();
        }

        public async Task UpdateTransaction()
        {
            WebRequest.Update();
        }

        public async Task DeleteTransaction()
        {

            WebRequest.Delete();
        }
        #endregion //CRUD

        #region Convertion Methods
        public override BankingWebAPI2.Models.Transaction ToWebApiModel()
        {
            return new BankingWebAPI2.Models.Transaction() { Id = this.Id, PersonId = this.PersonId, Description = this.Description, Account = this.Account.ToWebApiModel(), Person = this.Person.ToWebApiModel() };
        }

        public override void FromWebApiModel(BankingWebAPI2.Models.Transaction Transaction)
        {
            this.Id = Transaction.Id;
            this.PersonId = Transaction.PersonId;
            this.Description = Transaction.Description;
            this.Account.FromWebApiModel(Transaction.Account);
            this.Person.FromWebApiModel(Transaction.Person);
        }
        #endregion //Convertion Methods
    }
}
