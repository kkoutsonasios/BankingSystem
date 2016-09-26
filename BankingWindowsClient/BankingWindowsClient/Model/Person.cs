using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BankingWindowsClient.Model
{
    public class Person : BaseModel
    {

        #region Properties
        public Person()
        {

        }
        private long _id;
        public long Id { get { return this._id; } set { this._id = value; RaisePropertyChangedEvent("Id"); } }

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
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61249/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                BankingWebAPI2.Models.Person Person = this.ToWebApiModel();

                HttpResponseMessage response = await client.PostAsJsonAsync("api/People", Person);
            }
        }


        public async Task ReadPerson()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61249/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync(string.Format("api/People/{0}", this.Id));
                if (response.IsSuccessStatusCode)
                {
                    BankingWebAPI2.Models.Person Person = await response.Content.ReadAsAsync<BankingWebAPI2.Models.Person>();

                    this.FromWebApiModel(Person);
                }
            }
        }

        public async Task UpdatePerson()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61249/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                BankingWebAPI2.Models.Person Person = this.ToWebApiModel();

                HttpResponseMessage response = await client.PutAsJsonAsync(string.Format("api/People/{0}", this.Id), Person);
            }
        }

        public async Task DeletePerson()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61249/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                BankingWebAPI2.Models.Person Person = this.ToWebApiModel();

                HttpResponseMessage response = await client.DeleteAsync(string.Format("api/People/{0}", this.Id));
            }
        }
        #endregion //CRUD

        #region Convertion Methods
        public BankingWebAPI2.Models.Person ToWebApiModel()
        {
            return new BankingWebAPI2.Models.Person() { Id = this.Id, FirstName = this.FirstName, LastName = this.LastName, IdNumber = this.IdNumber };
        }

        public void FromWebApiModel(BankingWebAPI2.Models.Person person)
        {
            this.Id = person.Id;
            this.FirstName = person.FirstName;
            this.LastName = person.LastName;
            this.IdNumber = person.IdNumber;
        }
        #endregion //Convertion Methods
    }


}
