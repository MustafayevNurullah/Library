using Library.Entity;
using Library.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.Command
{
    public class UpdateWorker : ICommand
    {
        public event EventHandler CanExecuteChanged;
        WorkerViewModel workerViewModel { get; set; }
        public UpdateWorker (WorkerViewModel workerViewModel)
        {
            this.workerViewModel = workerViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var item = workerViewModel.Workers.FirstOrDefault(x => x.Id == workerViewModel.CurrentWorker.Id);
            int index = workerViewModel.Workers.IndexOf(item);
            workerViewModel.Workers[index] = workerViewModel.CurrentWorker;
            string json = JsonConvert.SerializeObject(workerViewModel.Workers);
            System.IO.File.WriteAllText("Workers.json", json);
            workerViewModel.CurrentWorker = new WorkerEntity();
            workerViewModel.SelectWorker = new WorkerEntity();
        }
    }
}
