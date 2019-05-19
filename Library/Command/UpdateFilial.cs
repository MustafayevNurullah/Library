using Library.View;
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
    public class UpdateFilial : ICommand
    {
        public event EventHandler CanExecuteChanged;
        FilialViewModel filialViewModel { get; set; }
        public UpdateFilial(FilialViewModel filialViewModel)
        {
            filialViewModel = this.filialViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var item = filialViewModel.Filials.FirstOrDefault(x => x.Id == filialViewModel.CurrentFilial.Id);
            int index=filialViewModel.Filials.IndexOf(item);
            filialViewModel.Filials[index] = filialViewModel.CurrentFilial;
            string json = JsonConvert.SerializeObject(filialViewModel.Filials);
            System.IO.File.WriteAllText("Filials.json", json);
        }
    }
}
