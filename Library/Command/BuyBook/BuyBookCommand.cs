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
            Users = new List<UserEntity>();
            Users = App.Db.UserRepository.GetAll();
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            App.Db.SaleRepository.Insert(buyViewModel.CurrentBuyBook);
            buyViewModel.CurrentBuyBook = new BuyEntity();
        }
    }
}
