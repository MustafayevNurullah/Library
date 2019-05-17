using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModel
{
   public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnpropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this,e);
        }

    }
}
