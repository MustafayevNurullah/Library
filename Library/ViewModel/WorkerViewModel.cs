using Library.Command;
using Library.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModel
{
   public class WorkerViewModel:BaseViewModel
    {
       public AddWorker addWorker { get; set; }
      public  UpdateWorker UpdateWorker { get; set; }
      public  DeleteWorker DeleteWorker { get; set; }
      public   WorkerViewModel()
        {

            addWorker = new AddWorker(this);
            UpdateWorker = new UpdateWorker(this);
            DeleteWorker = new DeleteWorker(this);
            CurrentWorker = new WorkerEntity();
            SelectWorker = new WorkerEntity();
           
        }
    private WorkerEntity currentworker;
        public WorkerEntity CurrentWorker
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
        private WorkerEntity selectworker;
        public WorkerEntity SelectWorker
        {
            get
            {
                return selectworker;
            }
            set
            {
                selectworker = value;
                CurrentWorker = selectworker.Clone();
                OnpropertyChanged(new PropertyChangedEventArgs(nameof(SelectWorker)));
            }
        }
        private ObservableCollection<WorkerEntity> workers;
        public ObservableCollection<WorkerEntity> Workers
        {
            get
            {
                return workers;
            }
            set
            {
                workers = value;
                OnpropertyChanged(new PropertyChangedEventArgs("Workers"));
            }
        }
        public List<FilialEntity> filials { get; set; }
    }
}
