using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModel
{
    class CustomerViewModel:BaseViewModel
    {


        private CustomerViewModel currentcustomer;
        public CustomerViewModel CurrentCustomer
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


        private CustomerViewModel selectcustomer;
        public CustomerViewModel SelectCustomer
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
        private ObservableCollection<CustomerViewModel> customers;
        public ObservableCollection<CustomerViewModel> Customers
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
