using Library.Entity;
using Library.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.Command
{
    public class UpdateBook : ICommand
    {
        public event EventHandler CanExecuteChanged;
        BookViewModel bookViewModel { get; set; }

        public UpdateBook( BookViewModel bookViewModel)
        {
            this.bookViewModel = bookViewModel;

        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var item = bookViewModel.Books.FirstOrDefault(x => x.Id == bookViewModel.SelectBook.Id);
            int index = bookViewModel.Books.IndexOf(item);
            bookViewModel.Books[index] = bookViewModel.CurrentBook;
            App.Db.BookRepository.Update(bookViewModel.CurrentBook);
            bookViewModel.CurrentBook = new BookEntity();
            bookViewModel.SelectBook = new BookEntity();
        }
    }
}
