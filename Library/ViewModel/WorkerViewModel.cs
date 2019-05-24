using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModel
{
   public class WorkerViewModel:BaseViewModel
    {
        private WorkerViewModel currentworker;
        public WorkerViewModel CurrentWorker
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
        private WorkerViewModel selectworker;
        public WorkerViewModel SelectWorker
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
        private ObservableCollection<FilialViewModel> filials;
        public ObservableCollection<FilialViewModel> Filials
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
