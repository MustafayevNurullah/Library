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
            var item = bookViewModel.Books.FirstOrDefault(x => x.Id == bookViewModel.CurrentBook.Id);
            if (item == null)
            {

                if (bookViewModel.Books.Count != 0)
                {
                    bookViewModel.CurrentBook.Id = bookViewModel.Books[bookViewModel.Books.Count - 1].Id + 1;
                }
                else
                {
                    bookViewModel.CurrentBook.Id = 1;
                }
                bookViewModel.Books.Add(bookViewModel.CurrentBook);
                //string json = JsonConvert.SerializeObject(bookViewModel.Books);
                //System.IO.File.WriteAllText("Filials.json", json);
                bookViewModel.CurrentBook = new BookEntity();
                bookViewModel.SelectBook = new BookEntity();
            }
        }
    }
}
