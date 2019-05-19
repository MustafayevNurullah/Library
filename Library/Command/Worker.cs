using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.Command
{
    public class Worker : ICommand
    {
        public event EventHandler CanExecuteChanged;
        MainView mainView { get; set; }

        public Worker(MainView MainView)
        {
            mainView = MainView;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            WorkerView workerView = new WorkerView();
            workerView.ShowDialog();
            mainView.Close();
        }
    }
}
