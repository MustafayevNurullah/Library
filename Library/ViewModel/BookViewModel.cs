using Library.Command;
using Library.Command.BuyBook;
using Library.Command.Rent;
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
        public DeleteBook DeleteBook { get; set; }
        public UpdateBook UpdateBook { get; set; }
        public BuyBook BuyBookCMD { get; set; }
        public Rent RentCMD { get; set; }

        public BookViewModel(MainViewModel mainViewModel)
        {
            Books = new ObservableCollection<BookEntity>();
            BuyBookCMD = new BuyBook(mainViewModel,this);
            RentCMD = new Rent(mainViewModel, this);
            addBook = new AddBook(this);
            DeleteBook = new DeleteBook(this);
            UpdateBook = new UpdateBook(this);
            currentbook = new BookEntity();
            selectbook = new BookEntity();
            if (File.Exists("Filials.json"))
            {
                string jsonFilial = File.ReadAllText("Filials.json");
               this.filials = JsonConvert.DeserializeObject<List<FilialEntity>>(jsonFilial);
            }
            if (File.Exists("Books.json"))
            {
                string jsonBook = File.ReadAllText("Books.json");
                this.Books = JsonConvert.DeserializeObject<ObservableCollection<BookEntity>>(jsonBook);
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
                if (value != null)
                {
                    CurrentBook = SelectBook.Clone();
                }
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
     
        
        public List<FilialEntity> filials { get; set; }
    }
}
