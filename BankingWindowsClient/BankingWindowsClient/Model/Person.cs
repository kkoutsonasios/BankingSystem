using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BankingWebAPI2.Models;

namespace BankingWindowsClient.Model
{
    public class Person : BaseModel<BankingWebAPI2.Models.Person>
    {
        #region Constructors
        public Person()
        {
            Controler = "api/People";
            WebRequest = new Tools.WebApi<Person, BankingWebAPI2.Models.Person>(this);
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
            BankingWebAPI2.Models.Person InnerPerson = person;
            this.Id = InnerPerson.Id;
            this.FirstName = InnerPerson.FirstName;
            this.LastName = InnerPerson.LastName;
            this.IdNumber = InnerPerson.IdNumber;
        }
        #endregion //Convertion Methods
    }


}
