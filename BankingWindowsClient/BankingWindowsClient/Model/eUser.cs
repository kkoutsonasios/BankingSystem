using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingWindowsClient.Model
{
    class eUser : BaseModel<BankingWebAPI2.Models.eUser>
    {
        #region Constructors
        public eUser()
        {
            Controler = "api/eUsers";
            WebRequest = new Tools.WebApi<eUser, BankingWebAPI2.Models.eUser>(this);
        }

        #endregion //Constructors

        #region Members
        private Tools.WebApi<eUser, BankingWebAPI2.Models.eUser> WebRequest;
        #endregion //Members

        #region Properties

        private long _id;
        public override long Id { get { return this._id; } set { this._id = value; RaisePropertyChangedEvent("Id"); } }

        private long _personId;
        public long PersonId { get { return this._personId; } set { this._personId = value; RaisePropertyChangedEvent("PersonId"); } }

        private string _userName;
        public string UserName { get { return this._userName; } set { this._userName = value; RaisePropertyChangedEvent("UserName"); } }

        private string _passwordHash;
        public string PasswordHash { get { return this._passwordHash; } set { this._passwordHash = value; RaisePropertyChangedEvent("PasswordHash"); } }

        private Person _person;
        public Person Person { get { return this._person; } set { this._person = value; RaisePropertyChangedEvent("Person"); } }

        #endregion //Properties

        #region CRUD
        public async Task CreateeUser()
        {
            WebRequest.Create();
        }

        public async Task ReadeUser()
        {
            WebRequest.Read();
        }

        public async Task UpdateeUser()
        {
            WebRequest.Update();
        }

        public async Task DeleteeUser()
        {

            WebRequest.Delete();
        }
        #endregion //CRUD

        #region Convertion Methods
        public override BankingWebAPI2.Models.eUser ToWebApiModel()
        {
            return new BankingWebAPI2.Models.eUser() { Id = this.Id, UserName = this.UserName, PasswordHash = this.PasswordHash, Person = this.Person.ToWebApiModel() };
        }

        public override void FromWebApiModel(BankingWebAPI2.Models.eUser eUser)
        {
            this.Id = eUser.Id;
            this.UserName = eUser.UserName;
            this.PasswordHash = eUser.PasswordHash;
            this.Person.FromWebApiModel(eUser.Person);
        }
        #endregion //Convertion Methods
    }
}
