using Library.Entity;
using Library.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.Command
{
    public class AddCustomer : ICommand
    {
        public event EventHandler CanExecuteChanged;
        CustomerViewModel customerViewModel { get; set; }

        public AddCustomer(CustomerViewModel customerViewModel)
        {
            this.customerViewModel = customerViewModel;
           
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var item = customerViewModel.Customers.FirstOrDefault(x => x.Id == customerViewModel.CurrentCustomer.Id);
            if (item == null)
            {

                if (customerViewModel.Customers.Count != 0)
                {
                    customerViewModel.CurrentCustomer.Id = customerViewModel.Customers[customerViewModel.Customers.Count - 1].Id + 1;
                }
                else
                {
                    customerViewModel.CurrentCustomer.Id = 1;
                }
                customerViewModel.Customers.Add(customerViewModel.CurrentCustomer);
                App.Db.CustomerRepository.Insert(customerViewModel.CurrentCustomer);
                customerViewModel.CurrentCustomer = new CustomerEntity();
                customerViewModel.SelectCustomer = new CustomerEntity();
            }

        }
    }
}
