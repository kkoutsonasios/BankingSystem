using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public void CollectionToObservable<T,Z>(ObservableCollection<T> ObCol, ICollection<Z> IColl) where T : BaseModel<Z>, new() where Z : BankingWebAPI2.Models.iBaseWebModel
        {
            ObCol.Clear();
            if (IColl != null)
            {
                foreach (Z obj in IColl)
                {
                    T Converter = new T();
                    Converter.FromWebApiModel(obj);
                    ObCol.Add(Converter);
                }
            }
        }

        public ICollection<Z> ObservableToCollection<T, Z>(ObservableCollection<T> ObCol, ICollection<Z> IColl) where T : BaseModel<Z> where Z : BankingWebAPI2.Models.iBaseWebModel, new()
        {
            IColl.Clear();
            if (ObCol != null)
            {
                foreach (T obj in ObCol)
                {
                    IColl.Add(obj.ToWebApiModel());
                }
            }

            return IColl;
        }

    }


}
