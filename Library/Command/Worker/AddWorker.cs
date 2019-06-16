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
    public class AddWorker : ICommand
    {
        public event EventHandler CanExecuteChanged;
        WorkerViewModel workerViewModel { get; set; }
        public AddWorker(WorkerViewModel workerViewModel)
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
            if (item == null)
            {

                if (workerViewModel.Workers.Count != 0)
                {
                    workerViewModel.CurrentWorker.Id = workerViewModel.Workers[workerViewModel.Workers.Count - 1].Id + 1;
                }
                else
                {
                    workerViewModel.CurrentWorker.Id = 1;
                }
                workerViewModel.Workers.Add(workerViewModel.CurrentWorker);
                
                App.Db.WorkerRepository.Insert(workerViewModel.CurrentWorker);
                workerViewModel.CurrentWorker = new WorkerEntity();
                workerViewModel.SelectWorker = new WorkerEntity();
            }
        }
    }
}
