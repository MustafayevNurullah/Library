using Library.Entity;
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
   public class RentReportViewModel:BaseViewModel
    {


        public RentReportViewModel()
        {

            CurrenRentReport = new RentEntity();
            Selectrentreport = new RentEntity();
            Rentrepors = new ObservableCollection<RentEntity>();
            if (File.Exists("RentBooks.json"))
            {
                string jsonFilial = File.ReadAllText("RentBooks.json");
                this.Rentrepors = JsonConvert.DeserializeObject<ObservableCollection<RentEntity>>(jsonFilial);
            }

        }


        RentEntity currentrentreport { get; set; }
        public RentEntity CurrenRentReport
        {
            get
            {
                return currentrentreport;
            }
            set
            {
                currentrentreport = value;
                OnpropertyChanged(new PropertyChangedEventArgs(nameof(CurrenRentReport)));
            }
        }
        private RentEntity selectrentreport;
        public RentEntity Selectrentreport
        {
            get
            {
                return selectrentreport;
            }
            set
            {
                selectrentreport = value;
                if (value != null)
                {
                    CurrenRentReport = Selectrentreport.Clone();
                }
                OnpropertyChanged(new PropertyChangedEventArgs(nameof(Selectrentreport)));
            }
        }
        private ObservableCollection<RentEntity> rentrepors;

        public ObservableCollection<RentEntity> Rentrepors
        {
            get
            {

                return rentrepors;
            }
            set
            {

                rentrepors = value;
                OnpropertyChanged(new PropertyChangedEventArgs(("Rentrepors")));
            }
        }


    }
}
