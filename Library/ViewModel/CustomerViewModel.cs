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
   public class CustomerViewModel:BaseViewModel
    {
       public  AddCustomer addCustomer { get; set; }
       public DeleteCustomer deleteCustomer { get; set; }
      public  UpdateCustomer updateCustomer { get; set; }
        public CustomerViewModel()
        {
            addCustomer = new AddCustomer(this);
            deleteCustomer = new DeleteCustomer(this);
            updateCustomer = new UpdateCustomer(this);
            SelectCustomer = new CustomerEntity();
            CurrentCustomer = new CustomerEntity();
          
        }

        private CustomerEntity currentcustomer;
        public CustomerEntity CurrentCustomer
        {


            get
            {
                return currentcustomer;
            }
            set
            {
                currentcustomer = value;

                OnpropertyChanged(new PropertyChangedEventArgs(nameof(CurrentCustomer)));
            }

        }


        private CustomerEntity selectcustomer;
        public CustomerEntity SelectCustomer
        {
            get
            {
                return selectcustomer;
            }
            set
            {
                selectcustomer = value;
                if(value!=null)
                {

                CurrentCustomer = SelectCustomer.Clone();
                }

                OnpropertyChanged(new PropertyChangedEventArgs(nameof(SelectCustomer)));
            }
        }
        private ObservableCollection<CustomerEntity> customers;
        public ObservableCollection<CustomerEntity> Customers
        {
            get
            {
                return customers;
            }
            set
            {
                customers = value;
                OnpropertyChanged(new PropertyChangedEventArgs("Customers"));
            }
        }

    }
}
