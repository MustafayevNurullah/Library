using Library.Entity;
using Library.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.Command
{
    public class AddBook : ICommand
    {
        private BookViewModel bookViewModel { get; set; }
        public AddBook (BookViewModel BookViewModel)
        {
            bookViewModel = BookViewModel;
           
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {

            return true;
        }
        public void Execute(object parameter)
        {
                bookViewModel.Books.Add(bookViewModel.CurrentBook);
            App.Db.BookRepository.Insert(bookViewModel.CurrentBook);         
                bookViewModel.CurrentBook = new BookEntity();
                bookViewModel.SelectBook = new BookEntity();
        }
    }
}
