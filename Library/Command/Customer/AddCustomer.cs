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
        List<UserEntity> Users;

        public AddCustomer(CustomerViewModel customerViewModel)
        {
            this.customerViewModel = customerViewModel;
            if (File.Exists("Users.json"))
            {
                string jsonFilial = File.ReadAllText("Users.json");
                this.Users = JsonConvert.DeserializeObject<List<UserEntity>>(jsonFilial);
            }
        }

        public bool CanExecute(object parameter)
        {
            return Users.FirstOrDefault(x => x.Presently == true).CanCreateCustomer;
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
                string json = JsonConvert.SerializeObject(customerViewModel.Customers);
                System.IO.File.WriteAllText("Customers.json", json);
                customerViewModel.CurrentCustomer = new CustomerEntity();
                customerViewModel.SelectCustomer = new CustomerEntity();
            }

        }
    }
}
