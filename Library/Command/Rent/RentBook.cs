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
            if (File.Exists("Users.json"))
            {
                string jsonFilial = File.ReadAllText("Users.json");
                this.Users = JsonConvert.DeserializeObject<List<UserEntity>>(jsonFilial);
            }
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var item = rentViewModel.RetnBooks.FirstOrDefault(x => x.Id == rentViewModel.CurrentRentBook.Id);
            if (item == null)
            {
                if (rentViewModel.RetnBooks.Count != 0)
                {
                    rentViewModel.CurrentRentBook.Id = rentViewModel.RetnBooks[rentViewModel.RetnBooks.Count - 1].Id + 1;
                }
                else
                {
                    rentViewModel.CurrentRentBook.Id = 1;
                }
                rentViewModel.CurrentRentBook.UserId = Users[Users.IndexOf(Users.FirstOrDefault(x => x.Presently == true))];
                rentViewModel.RetnBooks.Add(rentViewModel.CurrentRentBook);
                string json = JsonConvert.SerializeObject(rentViewModel.RetnBooks);
                System.IO.File.WriteAllText("RentBooks.json", json);
                rentViewModel.CurrentRentBook = new RentEntity();
                rentViewModel.SelectRentBook = new RentEntity();
            }
        }
    }
}
