using Library.Command.Login;
using Library.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Library.ViewModel
{
   public class LoginViewModel:BaseViewModel
    {

      public   Login login { get; set; }
       public View.Login Login { get; set; }
        public LoginViewModel( View.Login Login)
        {
            this.Login = Login;
            login = new Login(this);
            CurrentUser = new UserEntity();
          
        }
        
      UserEntity currentuser;
       public UserEntity CurrentUser
        {
            get
            {

       
                return currentuser;
            }
            set
            {
                currentuser = value;
                OnpropertyChanged(new PropertyChangedEventArgs("CurrentUser"));
            }
            
        }
        private ObservableCollection<UserEntity> users;
        public ObservableCollection<UserEntity> Users
        {
            get
            {

                return users;
            }
            set
            {
                
                    users = value;
                OnpropertyChanged(new PropertyChangedEventArgs(("Users")));
            }
        }


    }
}
