
using Library.Entity;
using Library.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Library.Command
{
    public class UpdateFilial : ICommand
    {
        public event EventHandler CanExecuteChanged;
        FilialViewModel filialViewModel { get; set; }
        public UpdateFilial(FilialViewModel filialViewModel)
        {
            this.filialViewModel = filialViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var a = filialViewModel.Filials.FirstOrDefault(x => x.Name == filialViewModel.CurrentFilial.Name && x.Address == filialViewModel.CurrentFilial.Address);
            if (a == null)
            {
                var item = filialViewModel.Filials.FirstOrDefault(x => x.Id == filialViewModel.CurrentFilial.Id);
                int index = filialViewModel.Filials.IndexOf(item);
                filialViewModel.Filials[index] = filialViewModel.CurrentFilial;
                string json = JsonConvert.SerializeObject(filialViewModel.Filials);
                System.IO.File.WriteAllText("Filials.json", json);
                filialViewModel.CurrentFilial = new FilialEntity();
                filialViewModel.SelectFilial = new FilialEntity();
            }
        }
    }
}
