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

namespace Library.Command.User
{
    public class DeleteUser : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public UserViewModel userViewModel { get; set; }
        public DeleteUser(UserViewModel userViewModel)
        {
            this.userViewModel = userViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            var item = userViewModel.Users.FirstOrDefault(x => x.Id == userViewModel.SelectUser.Id);
            App.Db.UserRepository.Delete(item);
            userViewModel.Users.Remove(item);
            ObservableCollection<UserEntity> NewFilials = userViewModel.Users;
            for (int i = 0; i < NewFilials.Count; i++)
            {
                userViewModel.Users[i] = userViewModel.Users[i];
            }
            userViewModel.CurrentUser = new UserEntity();
            userViewModel.SelectUser = new UserEntity();
            }
    }
}
