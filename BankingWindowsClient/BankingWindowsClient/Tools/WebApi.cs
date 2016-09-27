using BankingWindowsClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BankingWindowsClient.Tools
{
    public class WebApi<T,X> where T : Model.BaseModel<X> where X : BankingWebAPI2.Models.iBaseWebModel
    {
        #region Constructors
        public WebApi(BaseModel<X> model)
        {
            this._model = model;
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
        private object _model;
        #endregion //Members

        #region Properties
        public T Model { get { return (T)this._model; } private set { this._model = value; } }
        #endregion

        #region CRUD
        public async void Create()
        {
            X WebApiModel = Model.ToWebApiModel();
            HttpResponseMessage response = await client.PostAsJsonAsync(Model.Controler, WebApiModel);
        }

        public async void Read()
        {
            HttpResponseMessage response = await client.GetAsync(string.Format("{0}/{1}", Model.Controler, Model.Id));
            if (response.IsSuccessStatusCode)
            {
                X WebApiModel = await response.Content.ReadAsAsync<X>();
                Model.FromWebApiModel(WebApiModel);
            }
        }

        public async void Update()
        {
            X WebApiModel = Model.ToWebApiModel();
            HttpResponseMessage response = await client.PutAsJsonAsync(string.Format("{0}/{1}", Model.Controler, Model.Id), WebApiModel);
        }

        public async void Delete()
        {
            X WebApiModel = Model.ToWebApiModel();
            HttpResponseMessage response = await client.DeleteAsync(string.Format("{0}/{1}", Model.Controler, Model.Id));
        }
        #endregion //CRUD
    }
}
