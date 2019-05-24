using Library.Entity;
using Library.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.Command
{
    public class DeleteBook : ICommand
    {
        public event EventHandler CanExecuteChanged;
        BookViewModel BookViewModel { get; set; }
        public DeleteBook(BookViewModel bookViewModel )
        {
            BookViewModel = bookViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var item = BookViewModel.Books.FirstOrDefault(x => x.Id == BookViewModel.SelectBook.Id);
            BookViewModel.Books.Remove(item);
            ObservableCollection<BookEntity> NewFilials = BookViewModel.Books;
            for (int i = 0; i < NewFilials.Count; i++)
            {
                BookViewModel.Books[i] = BookViewModel.Books[i];
            }
            string json = JsonConvert.SerializeObject(BookViewModel.Books);
            System.IO.File.WriteAllText("Books.json", json);
            BookViewModel.CurrentBook = new BookEntity();
            BookViewModel.SelectBook = new BookEntity();
        }
    }
}
