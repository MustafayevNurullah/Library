using Library.View;
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

        MainView mainView { get; set; }
        public Book(MainView MainView)
        {
            mainView = MainView;
        }

        public bool CanExecute(object parameter)
        {
            return true;

        }

        public void Execute(object parameter)
        {
            BookView bookView = new BookView();
            bookView.ShowDialog();
            mainView.Close();
        }
    }
}
