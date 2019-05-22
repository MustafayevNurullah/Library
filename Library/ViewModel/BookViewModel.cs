using Library.Command;
using Library.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModel
{
   public class BookViewModel:BaseViewModel
    {

        private BookEntity currentbook;
        public AddBook addBook { get; set; }
        public BookViewModel()
        {
            Books = new ObservableCollection<BookEntity>();

            addBook = new AddBook(this);
            currentbook = new BookEntity();
            selectbook = new BookEntity();
            filials = new List<FilialEntity>();
            if (File.Exists("Filials.json"))
            {
                string jsonFilial = File.ReadAllText("Filials.json");
               this.filials = JsonConvert.DeserializeObject<List<FilialEntity>>(jsonFilial);
                
            }
            
        }
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
        private int state=1;
        public int State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                OnpropertyChanged(new PropertyChangedEventArgs(nameof(State)));
            }
        }

        public List<FilialEntity> filials { get; set; }
    }
}
