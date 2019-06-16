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

namespace Library.Command.Rent
{
    public class RentBook : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public RentViewModel rentViewModel { get; set; }
        List<UserEntity> Users;

        public RentBook(RentViewModel rentViewModel)
        {
            this.rentViewModel = rentViewModel;
           
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            App.Db.RentRepository.Insert(rentViewModel.CurrentRentBook);
            rentViewModel.CurrentRentBook = new RentEntity();
        }
    }
}
