using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingWindowsClient.Model
{
    class Balance : BaseModel<BankingWebAPI2.Models.Balance>
    {
        #region Constructors
        public Balance()
        {
            Controler = "api/Balances";
            WebRequest = new Tools.WebApi<Balance, BankingWebAPI2.Models.Balance>(this);
        }

        #endregion //Constructors

        #region Members
        private Tools.WebApi<Balance, BankingWebAPI2.Models.Balance> WebRequest;
        #endregion //Members

        #region Properties

        private long _id;
        public override long Id { get { return this._id; } set { this._id = value; RaisePropertyChangedEvent("Id"); } }

        private long _accountId;
        public long AccountId { get { return this._accountId; } set { this._accountId = value; RaisePropertyChangedEvent("AccountId"); } }

        private double _amount;
        public double Amount { get { return this._amount; } set { this._amount = value; RaisePropertyChangedEvent("Amount"); } }

        public virtual Account Account { get; set; }

        #endregion //Properties

        #region CRUD
        public async Task CreateBalance()
        {
            WebRequest.Create();
        }

        public async Task ReadBalance()
        {
            WebRequest.Read();
        }

        public async Task UpdateBalance()
        {
            WebRequest.Update();
        }

        public async Task DeleteBalance()
        {

            WebRequest.Delete();
        }
        #endregion //CRUD

        #region Convertion Methods
        public override BankingWebAPI2.Models.Balance ToWebApiModel()
        {
            return new BankingWebAPI2.Models.Balance() { Id = this.Id, AccountId = this.AccountId, Amount = this.Amount};
        }

        public override void FromWebApiModel(BankingWebAPI2.Models.Balance Balance)
        {
            this.Id = Balance.Id;
            this.AccountId = Balance.AccountId;
            this.Amount = Balance.Amount;
        }
        #endregion //Convertion Methods
    }
}
