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
    public class RentViewModel:BaseViewModel
    {
        public List<CustomerEntity> customerList { get; set; }
        List<UserEntity> Users;
       public  RentBook rentBook { get; set; }
        public RentViewModel( )
        {
            rentBook = new RentBook(this);
            SelectRentBook = new RentEntity();
            
        }



        RentEntity currenrentbook { get; set; }
        public RentEntity CurrentRentBook
        {
            get
            {
                return currenrentbook;
            }
            set
            {
                currenrentbook = value;
                OnpropertyChanged(new PropertyChangedEventArgs(nameof(CurrentRentBook)));
            }
        }
        private RentEntity selectrentbook;
        public RentEntity SelectRentBook
        {
            get
            {
                return selectrentbook;
            }
            set
            {
                selectrentbook = value;
                if (value != null)
                {
                    CurrentRentBook = SelectRentBook.Clone();
                }
                OnpropertyChanged(new PropertyChangedEventArgs(nameof(SelectRentBook)));
            }
        }
        private ObservableCollection<RentEntity> rentbooks;
        public ObservableCollection<RentEntity> RetnBooks
        {
            get
            {

                return rentbooks;
            }
            set
            {

                rentbooks = value;
                OnpropertyChanged(new PropertyChangedEventArgs(("RetnBooks")));
            }
        }
    }
}
