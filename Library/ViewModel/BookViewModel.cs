using Library.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModel
{
    class BookViewModel:BaseViewModel
    {
        private Book currentbook;
        public Book CurrentBook
        {


            get
            {
                return currentbook;
            }
            set
            {
                currentbook = value;

                OnpropertyChanged(new PropertyChangedEventArgs(nameof(CurrentBook)));
            }

        }


        private Book selectbook;
        public Book SelectBook
        {
            get
            {
                return selectbook;
            }
            set
            {
                selectbook = value;

                OnpropertyChanged(new PropertyChangedEventArgs(nameof(SelectBook)));
            }
        }
        private ObservableCollection<Book> books;
        public ObservableCollection<Book> Books
        {
            get
            {
                return books;
            }
            set
            {
                books = value;
                OnpropertyChanged(new PropertyChangedEventArgs(("Books")));
            }
        }
    }
}
