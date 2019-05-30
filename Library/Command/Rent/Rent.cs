using Library.UserControls;
using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.Command.Rent
{
    public class Rent : ICommand
    {
        public event EventHandler CanExecuteChanged;
        MainViewModel mainViewModel { get; set; }
        BookViewModel BookViewModel { get; set; }

        public Rent(MainViewModel mainViewModel,BookViewModel bookViewModel)
        {

            this.mainViewModel = mainViewModel;
            this.BookViewModel = bookViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            mainViewModel.Window1.MainBorder.Child = new RentUserControl(BookViewModel);
        }
    }
}
