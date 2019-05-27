using Library.Entity;
using Library.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.Command
{
    public class DeleteCustomer : ICommand
    {
        public event EventHandler CanExecuteChanged;
         CustomerViewModel customerView { get; set; }
        public DeleteCustomer(CustomerViewModel customerView)
        {
            this.customerView = customerView;
        }



        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var item = customerView.Customers.FirstOrDefault(x => x.Id == customerView.SelectCustomer.Id);
            customerView.Customers.Remove(item);
            ObservableCollection<CustomerEntity> NewFilials = customerView.Customers;
            for (int i = 0; i < NewFilials.Count; i++)
            {
                customerView.Customers[i] = customerView.Customers[i];
            }
            string json = JsonConvert.SerializeObject(customerView.Customers);
            System.IO.File.WriteAllText("Books.json", json);
            customerView.CurrentCustomer = new CustomerEntity();
            customerView.SelectCustomer = new CustomerEntity();
        }
    }
}
