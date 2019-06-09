
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
    public class Book : ICommand
    {
        public event EventHandler CanExecuteChanged;
        List<UserEntity> Users;

        MainViewModel MainView { get; set; }
        public Book(MainViewModel MainView)
        {
            if (File.Exists("Users.json"))
            {
                string jsonFilial = File.ReadAllText("Users.json");
                this.Users = JsonConvert.DeserializeObject<List<UserEntity>>(jsonFilial);
            }
            this.MainView = MainView;
        }

        public bool CanExecute(object parameter)
        {
            //  return Users.FirstOrDefault(x => x.Presently == true).CanCreateBook;
            return true;


        }

        public void Execute(object parameter)
        {
            MainView.Window1.MainBorder.Child = new BookUser(MainView);
        }
    }
}
