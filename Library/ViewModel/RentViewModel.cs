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
            CurrentRentBook = new RentEntity();
            SelectRentBook = new RentEntity();
            RetnBooks = new ObservableCollection<RentEntity>();
            if (File.Exists("Customers.json"))
            {
                string jsonBook = File.ReadAllText("Customers.json");
                customerList = JsonConvert.DeserializeObject<List<CustomerEntity>>(jsonBook);
            }
            if (File.Exists("Users.json"))
            {
                string jsonFilial = File.ReadAllText("Users.json");
                this.Users = JsonConvert.DeserializeObject<List<UserEntity>>(jsonFilial);

                Users.RemoveAll(x => x.Presently == false);
            }
            if (File.Exists("Rent.json"))
            {
                string jsonBook = File.ReadAllText("BuyBooks.json");
                RetnBooks = JsonConvert.DeserializeObject<ObservableCollection<RentEntity>>(jsonBook);
            }
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
