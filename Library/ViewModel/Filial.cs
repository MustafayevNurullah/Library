using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModel
{
    class Filial:BaseViewModel
    {
        private Filial currentfilial;
        public Filial CurrentFilial
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
        private Filial selectfilial;
        public Filial SelectFilial
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
        private ObservableCollection<Filial> filials;
        public ObservableCollection<Filial> Filials
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
