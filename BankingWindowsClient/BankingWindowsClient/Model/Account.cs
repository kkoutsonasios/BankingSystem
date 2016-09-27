using System;
using System.Collections.Generic;
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
        }

        #endregion //Constructors

        #region Members
        private Tools.WebApi<Account, BankingWebAPI2.Models.Account> WebRequest;
        #endregion //Members

        #region Properties

        private long _id;
        public override long Id { get { return this._id; } set { this._id = value; RaisePropertyChangedEvent("Id"); } }

        private Nullable<long> _personId;
        public Nullable<long> PersonId { get { return this._personId; } set { this._personId = value; RaisePropertyChangedEvent("PersonId"); } }

        private string _description;
        public string Description { get { return this._description; } set { this._description = value; RaisePropertyChangedEvent("Description"); } }

        public virtual Person Person { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Balance> Balances { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> Transactions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> People { get; set; }

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
            return new BankingWebAPI2.Models.Account() { Id = this.Id, PersonId = this.PersonId, Description = this.Description };
        }

        public override void FromWebApiModel(BankingWebAPI2.Models.Account Account)
        {
            this.Id = Account.Id;
            this.PersonId = Account.PersonId;
            this.Description = Account.Description;
        }
        #endregion //Convertion Methods
    }
}
