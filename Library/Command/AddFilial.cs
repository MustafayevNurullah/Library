using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.Command
{
    public class AddFilial : ICommand
    {
        private FilialViewModel filialViewModel { get; set; }
        public AddFilial (FilialViewModel FilialViewModel)
        {
            filialViewModel = FilialViewModel;
        }


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            filialViewModel.Filials.Add(filialViewModel.CurrentFilial);
        }
    }
}
