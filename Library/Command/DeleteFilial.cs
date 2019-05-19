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
    public class DeleteFilial : ICommand
    {
        public event EventHandler CanExecuteChanged;
        FilialViewModel filialViewModel { get; set; }
        public DeleteFilial(FilialViewModel filialViewModel)
        {
            filialViewModel = this.filialViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
           var item= filialViewModel.Filials.FirstOrDefault(x => x.Id == filialViewModel.CurrentFilial.Id);
            filialViewModel.Filials.Remove(item);
            string json = JsonConvert.SerializeObject(filialViewModel.Filials);
            System.IO.File.WriteAllText("Filials.json", json);
        }
    }
}
