
using Library.Command;
using Library.Command.BuyBook;
using Library.Command.BuyReport;
using Library.Command.Customer;
using Library.Command.Logout;
using Library.Command.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModel
{
   public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Book BookCMD { get; set; }
        public Filial FilialCMD { get; set; }
        public Worker WorkerCMD { get; set; }
        public User UserCMD { get; set; }
        public Logout LogoutCMD { get; set; }
        public Customer CustomerCMD { get; set; }
        public BuyReport BuyReportCMD { get; set; }
        public MainViewModel(Window1 window1)
        {
            BuyReportCMD = new BuyReport(this);
            LogoutCMD = new Logout(this);
            UserCMD = new User(this);
            BookCMD = new Book(this);
            FilialCMD = new Filial(this);
            WorkerCMD = new Worker(this);
            CustomerCMD = new Customer(this);
            Window1 = window1;
        }
       public Window1 Window1;
    }
}
