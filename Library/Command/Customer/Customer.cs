using Library.Entity;
using Library.UserControls;
using Library.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.Command.Customer
{
    public class Customer : ICommand
    {
        public event EventHandler CanExecuteChanged;
        MainViewModel mainViewModel { get; set; }
        List<UserEntity> Users;

        public Customer(MainViewModel mainViewModel)
        {
            if (File.Exists("Users.json"))
            {
                string jsonFilial = File.ReadAllText("Users.json");
                this.Users = JsonConvert.DeserializeObject<List<UserEntity>>(jsonFilial);
            }
            this.mainViewModel = mainViewModel;

        }
        public bool CanExecute(object parameter)
        {
            return Users.FirstOrDefault(x => x.Presently == true).CanCreateCustomer;

        }

        public void Execute(object parameter)
        {
            mainViewModel.Window1.MainBorder.Child = new CustomerUserControl();

        }
    }
}
