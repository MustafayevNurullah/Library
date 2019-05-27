using Library.Entity;
using Library.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.Command.Login
{
    public class Login : ICommand
    {
        public event EventHandler CanExecuteChanged;
      public  LoginViewModel loginViewModel { get; set; }
        public Login(LoginViewModel loginViewModel)
        {
            this.loginViewModel = loginViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

          var item=loginViewModel.Users.FirstOrDefault(x => x.Username == loginViewModel.CurrentUser.Username && x.Password==loginViewModel.CurrentUser.Password);
            if(item!=null)
            {
            var index = loginViewModel.Users.IndexOf(item);
                loginViewModel.Users[index].Presently = true;
                string json = JsonConvert.SerializeObject(loginViewModel.Users);
                System.IO.File.WriteAllText("Users.json", json);
                Window1 window1 = new Window1();
                loginViewModel.Login.Close();
                window1.ShowDialog();
            }

        }
    }
}
