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

namespace Library.Command.BuyBook
{
    public class BuyBookCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public BuyViewModel buyViewModel { get; set; }
        List<UserEntity> Users;

        public BuyBookCommand(BuyViewModel buyViewModel)
        {
            this.buyViewModel = buyViewModel;
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
            var item = buyViewModel.BuyBooks.FirstOrDefault(x => x.Id == buyViewModel.CurrentBuyBook.Id);
            if (item == null)
            {
                if (buyViewModel.BuyBooks.Count != 0)
                {
                    buyViewModel.CurrentBuyBook.Id = buyViewModel.BuyBooks[buyViewModel.BuyBooks.Count - 1].Id + 1;
                }
                else
                {
                    buyViewModel.CurrentBuyBook.Id = 1;
                }
                buyViewModel.CurrentBuyBook.UserId = Users[Users.IndexOf(Users.FirstOrDefault(x => x.Presently == true))];
                buyViewModel.BuyBooks.Add(buyViewModel.CurrentBuyBook);
                string json = JsonConvert.SerializeObject(buyViewModel.BuyBooks);
                System.IO.File.WriteAllText("BuyBooks.json", json);
                buyViewModel.CurrentBuyBook = new BuyEntity();
                buyViewModel.SelectBuyBook = new BuyEntity();
            }
        }
    }
}
