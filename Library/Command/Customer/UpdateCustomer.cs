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
            this.customerViewModel = customerViewMOdel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var item = customerViewModel.Customers.FirstOrDefault(x => x.Id == customerViewModel.CurrentCustomer.Id);
            int index = customerViewModel.Customers.IndexOf(item);
            App.Db.CustomerRepository.Update(item);
            customerViewModel.Customers[index] = customerViewModel.CurrentCustomer;
            customerViewModel.CurrentCustomer = new CustomerEntity();
            customerViewModel.SelectCustomer = new CustomerEntity();
        }
    }
}
