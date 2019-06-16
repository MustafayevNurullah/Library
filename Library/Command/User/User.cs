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

namespace Library.Command.User
{
   public class User : ICommand
    {
        public event EventHandler CanExecuteChanged;
        MainViewModel MainViewModel { get; set; }
        List<UserEntity> Users;
        public User(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
            Users = new List<UserEntity>();
            Users = App.Db.UserRepository.GetAll();
        }
        public bool CanExecute(object parameter)
        {
            
            return Users.FirstOrDefault(x => x.Presently == true).CanCreateUser;
            //return true;
        }

        public void Execute(object parameter)
        {
            MainViewModel.Window1.MainBorder.Child = new UserUserControl();
        }
    }
}
