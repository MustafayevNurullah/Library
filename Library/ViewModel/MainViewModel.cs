
using Library.Command;
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
        public MainViewModel(Window1 window1)
        {
            BookCMD = new Book(this);
            FilialCMD = new Filial(this);
            WorkerCMD = new Worker(this);
            Window1 = window1;
        }
       public Window1 Window1;
    }
}
