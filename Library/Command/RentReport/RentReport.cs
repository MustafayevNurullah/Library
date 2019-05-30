using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.Command.RentReport
{
    public class RentReport : ICommand
    {
        public event EventHandler CanExecuteChanged;
        MainViewModel mainViewModel;
public RentReport(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mainViewModel.Window1.MainBorder.Child = new UserControls.Rentreport();
        }
    }
}
