
using Library.UserControls;
using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Library.Command
{

    public class Filial : ICommand
    {
        public event EventHandler CanExecuteChanged;
        MainViewModel MainViewModel { get; set; }
        public Filial (MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MainViewModel.Window1.MainBorder.Child = new FilialUserControl();
        }
    }
}
