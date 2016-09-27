using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankingWindowsClient.Model
{


    public class BaseModel<X> : INotifyPropertyChanged where X : BankingWebAPI2.Models.iBaseWebModel
    {
        public virtual long Id { get; set; }

        public string Controler { get; set; }

        public virtual X ToWebApiModel() 
        {
            return (X)new object();
        }

        public virtual void FromWebApiModel(X webApiModel)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChangedEvent(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
