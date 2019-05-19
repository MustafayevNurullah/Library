using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModel
{
  public  class MainViewModel
    {
        public MainView MainWindow { get; set; }
        public MainViewModel(MainView MainWindow)
        {
            this.MainWindow = MainWindow;
        }
        public Command.Filial Filial => new Command.Filial(MainWindow);
        public Command.Book Book => new Command.Book(MainWindow);
        public Command.Customer Customer => new Command.Customer(MainWindow);
        public Command.Worker Worker => new Command.Worker(MainWindow);
    }
}
