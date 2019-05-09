using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModel
{
    class Worker:BaseViewModel
    {
        private Worker currentworker;
        public Worker CurrentWorker
        {
            get
            {
                return currentworker;
            }
            set
            {
                currentworker = value;

                OnpropertyChanged(new PropertyChangedEventArgs(nameof(CurrentWorker)));
            }
        }
        private Worker selectworker;
        public Worker SelectWorker
        {
            get
            {
                return selectworker;
            }
            set
            {
                selectworker = value;

                OnpropertyChanged(new PropertyChangedEventArgs(nameof(SelectWorker)));
            }
        }
        private ObservableCollection<Filial> filials;
        public ObservableCollection<Filial> Filials
        {
            get
            {
                return filials;
            }
            set
            {
                filials = value;
                OnpropertyChanged(new PropertyChangedEventArgs("Filials"));
            }
        }
    }
}
