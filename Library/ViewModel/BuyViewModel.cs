using Library.Command.BuyBook;
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
  public  class BuyViewModel:BaseViewModel
    {
        public List<CustomerEntity> customerList { get; set; }
       public BuyBookCommand buyBookCommand { get; set; }
            List<UserEntity> Users;
        public BuyViewModel()
        {
            buyBookCommand = new BuyBookCommand(this);
           // CurrentBuyBook = new BuyEntity();
            SelectBuyBook = new BuyEntity();
        }
        BuyEntity currenbuybook { get; set; }
        public BuyEntity CurrentBuyBook
        {
            get
            {
                return currenbuybook;
            }
            set
            {
                currenbuybook = value;
                OnpropertyChanged(new PropertyChangedEventArgs(nameof(CurrentBuyBook)));
            }
        }
        private BuyEntity selectbuybook;
        public BuyEntity SelectBuyBook
        {
            get
            {
                return selectbuybook;
            }
            set
            {
                selectbuybook = value;
                if (value != null)
                {
                    CurrentBuyBook = SelectBuyBook.Clone();
                }
                OnpropertyChanged(new PropertyChangedEventArgs(nameof(SelectBuyBook)));
            }
        }
        private ObservableCollection<BuyEntity> buybooks;
        public ObservableCollection<BuyEntity> BuyBooks
        {
            get
            {

                return buybooks;
            }
            set
            {

                buybooks = value;
                OnpropertyChanged(new PropertyChangedEventArgs(("BuyBooks")));
            }
        }

    }
}
