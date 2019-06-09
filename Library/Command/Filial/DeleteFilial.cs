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
    public class DeleteFilial : ICommand
    {
        public event EventHandler CanExecuteChanged;
        FilialViewModel filialViewModel { get; set; }
        public DeleteFilial(FilialViewModel filialViewModel)
        {
           this.filialViewModel = filialViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            var item= filialViewModel.Filials.FirstOrDefault(x => x.Id == filialViewModel.SelectFilial.Id);
            filialViewModel.Filials.Remove(item);
            App.Db.BranchRepository.Delete(item);
            filialViewModel.CurrentFilial = new FilialEntity();
            filialViewModel.SelectFilial = new FilialEntity();
        }
    }
}
