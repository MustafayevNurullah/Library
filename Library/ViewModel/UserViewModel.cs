using Library.Command.User;
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
using System.Windows.Controls;

namespace Library.ViewModel
{
    public class UserViewModel:BaseViewModel
    {

      public  AddUser addUser { get; set; }
       public UpdateUser updateUser { get; set; }
       public  DeleteUser deleteUser { get; set; }
        public UserViewModel()
        {
            addUser = new AddUser(this);
            updateUser = new UpdateUser(this);
            deleteUser = new DeleteUser(this);
            currentuser = new UserEntity();
            SelectUser = new UserEntity();
            permissions = new List<Permission>();
            Users = new ObservableCollection<UserEntity>();
        }
       UserEntity currentuser;
        object parameter;
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
        
        UserEntity selectuser;
        public UserEntity SelectUser
        {


            get
            {
                return selectuser;
            }
            set
            {
                if (value!=null)
                {

                if ( value.Presently != true)
                {
                    selectuser = value;
                    CurrentUser = selectuser.Clone();
                        


                    OnpropertyChanged(new PropertyChangedEventArgs("SelectUser"));
                   }
                }
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
       public  List<Permission> permissions { get; set; }
    }
}
