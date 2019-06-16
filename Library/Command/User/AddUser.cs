using Library.Entity;
using Library.Hash;
using Library.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Library.Command.User
{
    public class AddUser : ICommand
    {
        public event EventHandler CanExecuteChanged;
        UserViewModel userViewModel { get; set; }

        public AddUser(UserViewModel userViewModel)
        {
            this.userViewModel = userViewModel;
           
        }


        public bool CanExecute(object parameter)
        {
            return true;
        

        }

        public void Execute(object parameter)
        {
           
            var item = userViewModel.Users.FirstOrDefault(x => x.Username == userViewModel.CurrentUser.Username);
            if (item == null)
            {
                if (userViewModel.Users.Count != 0)
                {
                    userViewModel.CurrentUser.Id = userViewModel.Users[userViewModel.Users.Count - 1].Id + 1;
                }
                else
                {
                    userViewModel.CurrentUser.Id = 1;
                }
                userViewModel.CurrentUser.Password = (parameter as PasswordBox).Password;
                userViewModel.CurrentUser.Password=Encrypt_Decrypt.Encrypt(userViewModel.CurrentUser.Password);
                userViewModel.Users.Add(userViewModel.CurrentUser);
                App.Db.UserRepository.Insert(userViewModel.CurrentUser);
                (parameter as PasswordBox).Password = string.Empty;
                userViewModel.CurrentUser = new UserEntity();
                userViewModel.SelectUser = new UserEntity();
            }
        }
    }
}
