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
            Users = new List<UserEntity>();
            Users = App.Db.UserRepository.GetAll();
            this.mainViewModel = mainViewModel;

        }
        public bool CanExecute(object parameter)
        {
              return Users.FirstOrDefault(x => x.Presently == true).CanCreateCustomer;
            //return true;
        }

        public void Execute(object parameter)
        {
            mainViewModel.Window1.MainBorder.Child = new CustomerUserControl();

        }
    }
}
