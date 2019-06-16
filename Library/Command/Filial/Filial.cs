
using Library.Entity;
using Library.UserControls;
using Library.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Library.Command
{

    public class Filial : ICommand
    {
        List<UserEntity> Users;

        public event EventHandler CanExecuteChanged;
        MainViewModel MainViewModel { get; set; }
        public Filial (MainViewModel mainViewModel)
        {
            Users = new List<UserEntity>();
            Users = App.Db.UserRepository.GetAll();
            MainViewModel = mainViewModel;
        }
        public bool CanExecute(object parameter)
        {
              return Users.FirstOrDefault(x => x.Presently == true).CanCreateBranch;
            //return true;
        }

        public void Execute(object parameter)
        {
            
            MainViewModel.Window1.MainBorder.Child = new FilialUserControl();
        }
    }
}
