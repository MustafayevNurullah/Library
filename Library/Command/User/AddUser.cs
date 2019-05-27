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

namespace Library.Command.User
{
    public class AddUser : ICommand
    {
        public event EventHandler CanExecuteChanged;
        UserViewModel userViewModel { get; set; }
        List<UserEntity> Users;

        public AddUser(UserViewModel userViewModel)
        {
            this.userViewModel = userViewModel;
            if (File.Exists("Users.json"))
            {
                string jsonFilial = File.ReadAllText("Users.json");
                this.Users = JsonConvert.DeserializeObject<List<UserEntity>>(jsonFilial);
            }
        }


        public bool CanExecute(object parameter)
        {
            return Users.FirstOrDefault(x => x.Presently == true).CanCreateUser;

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
                userViewModel.Users.Add(userViewModel.CurrentUser);
                string json = JsonConvert.SerializeObject(userViewModel.Users);
                System.IO.File.WriteAllText("Users.json", json);
                userViewModel.CurrentUser = new UserEntity();
                userViewModel.SelectUser = new UserEntity();
            }
        }
    }
}
