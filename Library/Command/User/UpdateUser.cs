using Library.Entity;
using Library.Hash;
using Library.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.Command.User
{
    public class UpdateUser : ICommand
    {
        public event EventHandler CanExecuteChanged;
       UserViewModel userViewModel { get; set; }

        public UpdateUser(UserViewModel userViewModel)
        {
            this.userViewModel = userViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var item = userViewModel.Users.FirstOrDefault(x => x.Id == userViewModel.CurrentUser.Id);
            int index = userViewModel.Users.IndexOf(item);
            if(userViewModel.CurrentUser.Password!=userViewModel.Users[index].Password)
            {
            userViewModel.CurrentUser.Password = Encrypt_Decrypt.Encrypt(userViewModel.CurrentUser.Password);
            }
            item.Password = userViewModel.CurrentUser.Password;
            userViewModel.Users[index] = userViewModel.CurrentUser;
            App.Db.UserRepository.Update(userViewModel.CurrentUser);
            userViewModel.CurrentUser = new UserEntity();
            userViewModel.SelectUser = new UserEntity();
        }
    }
}
