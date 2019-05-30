using Library.Entity;
using Library.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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
            var passwordUser = (parameter as PasswordBox).Password;
          var item=loginViewModel.Users.FirstOrDefault(x => x.Username == loginViewModel.CurrentUser.Username && x.Password==passwordUser);
            if (item!=null)
            {
            var index = loginViewModel.Users.IndexOf(item);
                loginViewModel.Users[index].Presently = true;
                string json = JsonConvert.SerializeObject(loginViewModel.Users);
                System.IO.File.WriteAllText("Users.json", json);
                Window1 window1 = new Window1();
                loginViewModel.Login.Close();
                window1.ShowDialog();
            }
            else
            {
                if( loginViewModel.Users.FirstOrDefault(x => x.Username == loginViewModel.CurrentUser.Username )==null)
                {
                loginViewModel.Login.Username.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xFF, 0xFF, 0, 0));
                }
                if (loginViewModel.Users.FirstOrDefault(x => x.Password == loginViewModel.CurrentUser.Password)== null)
                {
                loginViewModel.Login.Password.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xFF, 0xFF, 0, 0));
                }
            }

        }
    }
}
