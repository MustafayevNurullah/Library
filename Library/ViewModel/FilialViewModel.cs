using Library.Command;
using Library.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModel
{
   public class FilialViewModel:BaseViewModel
    {

       public AddFilial Add => new AddFilial(this);
        public FilialViewModel()
        {
            currentfilial = new FilialEntity();
            selectfilial = new FilialEntity();
        }
        private FilialEntity currentfilial;
        public FilialEntity CurrentFilial
        {
             

            get
            {
                return currentfilial;
            }
            set
            {
                currentfilial = value;

                OnpropertyChanged(new PropertyChangedEventArgs(nameof(CurrentFilial)));
            }

        }
        private FilialEntity selectfilial;
        public FilialEntity SelectFilial
        {
            get
            {
                return selectfilial;
            }
            set
            {
                selectfilial = value;

                OnpropertyChanged(new PropertyChangedEventArgs(nameof(SelectFilial)));
            }
        }
        private ObservableCollection<FilialEntity> filials;
        public ObservableCollection<FilialEntity> Filials
        {
            get
            {
                return filials;
            }
            set
            {
                filials = value;
                OnpropertyChanged(new PropertyChangedEventArgs("Filials"));
            }
        }
    }
}
