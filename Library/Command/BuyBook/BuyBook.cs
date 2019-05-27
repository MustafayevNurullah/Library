using Library.UserControls;
using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.Command.BuyBook
{
    public class BuyBook : ICommand
    {
        public event EventHandler CanExecuteChanged;
      public  MainViewModel mainViewModel { get; set; }
        public BookViewModel BookViewModel { get; set; }
        public BuyBook(MainViewModel mainViewModel,BookViewModel bookViewModel)
        {
            this.mainViewModel = mainViewModel;
            BookViewModel = bookViewModel;
        }
        public bool CanExecute(object parameter)
        {
            
            return true;

        }

        public void Execute(object parameter)
        {
            mainViewModel.Window1.MainBorder.Child = new BuyUserControl(BookViewModel);
        }
    }
}
