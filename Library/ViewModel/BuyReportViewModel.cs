using Library.Command.BuyBook;
using Library.Entity;
using Library.UserControls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModel
{
  public  class BuyReportViewModel:BaseViewModel
    {
        public BuyReportViewModel()
        {
            CurrentBuyReport = new BuyEntity();
            selectbuyreport = new BuyEntity();
            Buyrepors = new ObservableCollection<BuyEntity>();
            if (File.Exists("BuyBooks.json"))
            {
                string jsonFilial = File.ReadAllText("BuyBooks.json");
                this.Buyrepors = JsonConvert.DeserializeObject<ObservableCollection<BuyEntity>>(jsonFilial);
            }
        }
        BuyEntity currentbuyreport { get; set; }
        public BuyEntity CurrentBuyReport
        {
            get
            {
                return currentbuyreport;
            }
            set
            {
                currentbuyreport = value;
                OnpropertyChanged(new PropertyChangedEventArgs(nameof(CurrentBuyReport)));
            }
        }
        private BuyEntity selectbuyreport;
        public BuyEntity Selectbuyreport
        {
            get
            {
                return selectbuyreport;
            }
            set
            {
                selectbuyreport = value;
                if (value != null)
                {
                    CurrentBuyReport = Selectbuyreport.Clone();
                }
                OnpropertyChanged(new PropertyChangedEventArgs(nameof(Selectbuyreport)));
            }
        }
        private ObservableCollection<BuyEntity> buyrepors;

        public ObservableCollection<BuyEntity> Buyrepors
        {
            get
            {

                return buyrepors;
            }
            set
            {

                buyrepors = value;
                OnpropertyChanged(new PropertyChangedEventArgs(("Buyrepors")));
            }
        }

    }
}
