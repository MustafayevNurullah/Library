using Library.Entity;
using Library.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.Command
{
    public class UpdateCustomer : ICommand
    {
        public event EventHandler CanExecuteChanged;
        CustomerViewModel customerViewModel { get; set; }
        public UpdateCustomer (CustomerViewModel customerViewMOdel)
        {
            this.customerViewModel = customerViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var item = customerViewModel.Customers.FirstOrDefault(x => x.Id == customerViewModel.SelectCustomer.Id);
            int index = customerViewModel.Customers.IndexOf(item);
            customerViewModel.Customers[index] = customerViewModel.CurrentCustomer;
            string json = JsonConvert.SerializeObject(customerViewModel.Customers);
            System.IO.File.WriteAllText("Customers.json", json);
            customerViewModel.CurrentCustomer = new CustomerEntity();
            customerViewModel.SelectCustomer = new CustomerEntity();
        }
    }
}
