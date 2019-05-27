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
            if (File.Exists("Users.json"))
            {
                string jsonFilial = File.ReadAllText("Users.json");
                users = JsonConvert.DeserializeObject<List<UserEntity>>(jsonFilial);
                var item=users.FirstOrDefault(x => x.Presently == true);
                users[users.IndexOf(item)].Presently = false;
                string json = JsonConvert.SerializeObject(users);
                System.IO.File.WriteAllText("Users.json", json);
            }
            mainViewModel.Window1.Close();
        }
    }
}
