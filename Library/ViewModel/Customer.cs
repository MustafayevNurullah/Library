using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModel
{
    class Customer:BaseViewModel
    {


        private Customer currentcustomer;
        public Customer CurrentCustomer
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


        private Customer selectcustomer;
        public Customer SelectCustomer
        {
            get
            {
                return selectcustomer;
            }
            set
            {
                selectcustomer = value;

                OnpropertyChanged(new PropertyChangedEventArgs(nameof(SelectCustomer)));
            }
        }
        private ObservableCollection<Customer> customers;
        public ObservableCollection<Customer> Customers
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
