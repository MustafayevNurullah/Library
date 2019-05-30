using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.Command.Ellipse
{
    public class Ellipse : ICommand
    {
        public event EventHandler CanExecuteChanged;
        MainViewModel mainViewModel { get; set; }
        public Ellipse()
        {
            this.mainViewModel = mainViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            System.Windows.Forms.MessageBox.Show("Test");
        }
    }
}
