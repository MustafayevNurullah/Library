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
        private BookEntity currentbook;
        public BookEntity CurrentBook
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


        private BookEntity selectbook;
        public BookEntity SelectBook
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
        private ObservableCollection<BookEntity> books;
        public ObservableCollection<BookEntity> Books
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
