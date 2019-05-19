using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Library.Command
{

  public  class Filial : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public MainView MainWindow { get; set; }
        public Filial(MainView mainView)
        {
            MainWindow = mainView;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            FilialView filialView = new FilialView();
            filialView.ShowDialog();
            MainWindow.Close();
        }
    }
}
