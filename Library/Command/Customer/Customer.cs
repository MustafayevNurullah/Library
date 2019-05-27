using Library.UserControls;
using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.Command.Customer
{
    public class Customer : ICommand
    {
        public event EventHandler CanExecuteChanged;
        MainViewModel mainViewModel { get; set; }
        public Customer(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;

        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mainViewModel.Window1.MainBorder.Child = new CustomerUserControl();

        }
    }
}
