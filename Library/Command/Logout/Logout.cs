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

namespace Library.Command.Logout
{
    public class Logout : ICommand
    {
        public event EventHandler CanExecuteChanged;
        MainViewModel mainViewModel { get; set; }
        public Logout(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            List<UserEntity> users = new List<UserEntity>();
            users = App.Db.UserRepository.GetAll();
                var item=users.FirstOrDefault(x => x.Presently == true);
                users[users.IndexOf(item)].Presently = false;
            App.Db.UserRepository.Update(users[users.IndexOf(item)]);
            mainViewModel.Window1.Close();
        }
    }
}
