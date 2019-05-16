using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModel
{
    class FilialViewModel:BaseViewModel
    {
        private FilialViewModel currentfilial;
        public FilialViewModel CurrentFilial
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
        private FilialViewModel selectfilial;
        public FilialViewModel SelectFilial
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
        private ObservableCollection<FilialViewModel> filials;
        public ObservableCollection<FilialViewModel> Filials
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
