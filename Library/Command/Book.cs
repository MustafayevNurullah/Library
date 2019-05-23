
using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.Command
{
    public class Book : ICommand
    {
        public event EventHandler CanExecuteChanged;

        MainViewModel MainView { get; set; }
        public Book(MainViewModel MainView)
        {
            this.MainView = MainView;
        }

        public bool CanExecute(object parameter)
        {
            return true;

        }

        public void Execute(object parameter)
        {
            MainView.Window1.MainBorder.Child = new BookUser();
        }
    }
}
