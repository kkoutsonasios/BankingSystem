using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankingWindowsClient.Model
{


    public class BaseModel : INotifyPropertyChanged
    {
        public virtual long Id { get; set; }

        public string Controler { get; set; }

        public virtual T ToWebApiModel<T>()
        {
            return (T)new object();
        }

        public virtual void FromWebApiModel<T>(T model) where T: BaseModel
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
