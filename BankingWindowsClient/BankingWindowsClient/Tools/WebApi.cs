using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BankingWindowsClient.Tools
{
    public class WebApi
    {
        #region Constructors
        public WebApi()
        {
            client = new HttpClient();
            Uri uri = new Uri("http://localhost:61249/");
            client.BaseAddress = uri;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion //Costructors

        #region Members
        private HttpClient client;
        private Uri uri;
        #endregion //Members

        #region CRUD
        public async void Create<T, X>(ref T Model) where T : Model.BaseModel
        {
            X WebApiModel = Model.ToWebApiModel<X>();
            HttpResponseMessage response = await client.PostAsJsonAsync(Model.Controler, WebApiModel);
        }

        public async void Read<T, X>(ref T Model) where T : Model.BaseModel
        {
            HttpResponseMessage response = await client.GetAsync(string.Format("{0}/{1}", Model.Controler, Model.Id));
            if (response.IsSuccessStatusCode)
            {
                X WebApiModel = await response.Content.ReadAsAsync<X>();
                Model.FromWebApiModel<X>(WebApiModel);
            }
        }

        public async void Update<T, X>(ref T Model) where T : Model.BaseModel
        {
            X WebApiModel = Model.ToWebApiModel<X>();
            HttpResponseMessage response = await client.PutAsJsonAsync(string.Format(("{0}/{1}", Model.Controler, Model.Id), WebApiModel);
        }

        public async void Delete<T, X>(ref T Model) where T : Model.BaseModel
        {
            X WebApiModel = Model.ToWebApiModel<X>();
            HttpResponseMessage response = await client.DeleteAsync(string.Format("{0}/{1}", Model.Controler, Model.Id));
        }
        #endregion //CRUD



    }
}
