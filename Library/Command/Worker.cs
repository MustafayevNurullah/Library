
using Library.UserControls;
using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.Command
{
    public class Worker:ICommand 
    {
       MainViewModel MainViewModel { get; set; }
        public Worker(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
        }


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            MainViewModel.Window1.MainBorder.Child = new WorkerUserControl();
        }
    }
}
