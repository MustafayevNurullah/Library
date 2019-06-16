using Library.Entity;
using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Library.UserControls
{
    /// <summary>
    /// Interaction logic for BuyUserControl.xaml
    /// </summary>
    public partial class BuyUserControl : UserControl
    {
        public BuyUserControl(BookViewModel bookViewModel)
        {
            InitializeComponent();
            BuyViewModel buyViewModel = new BuyViewModel();
            buyViewModel.CurrentBuyBook = new BuyEntity();
            buyViewModel.CurrentBuyBook.BookId = bookViewModel.CurrentBook.BranchId;
            buyViewModel.CurrentBuyBook.Book = bookViewModel.CurrentBook;
            buyViewModel.CurrentBuyBook.User = App.Db.UserRepository.GetUserPresenly();
            buyViewModel.CurrentBuyBook.UserId = buyViewModel.CurrentBuyBook.User.Id;
            buyViewModel.CurrentBuyBook.Date = DateTime.Now;
            buyViewModel.customerList = App.Db.CustomerRepository.GetAll();
            
            DataContext = buyViewModel;

        }
    }
}
