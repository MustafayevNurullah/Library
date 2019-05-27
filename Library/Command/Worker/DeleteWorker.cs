using Library.Entity;
using Library.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.Command
{
    public class DeleteWorker : ICommand
    {
        public event EventHandler CanExecuteChanged;
        WorkerViewModel workerViewModel { get; set; }

        public DeleteWorker(WorkerViewModel workerViewModel)
        {
            this.workerViewModel = workerViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var item = workerViewModel.Workers.FirstOrDefault(x => x.Id == workerViewModel.SelectWorker.Id);
            workerViewModel.Workers.Remove(item);
            ObservableCollection<WorkerEntity> NewFilials = workerViewModel.Workers;
            for (int i = 0; i < NewFilials.Count; i++)
            {
                workerViewModel.Workers[i] = workerViewModel.Workers[i];
            }
            string json = JsonConvert.SerializeObject(workerViewModel.Workers);
            System.IO.File.WriteAllText("Workers.json", json);
            workerViewModel.CurrentWorker = new WorkerEntity();
            workerViewModel.SelectWorker = new WorkerEntity();
        }
    }
}
