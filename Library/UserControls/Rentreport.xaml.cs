using Library.Entity;
using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Library.UserControls
{
    /// <summary>
    /// Interaction logic for Rentreport.xaml
    /// </summary>
    public partial class Rentreport : UserControl
    {
        public Rentreport()
        {
            InitializeComponent();
            RentViewModel rentViewModel = new RentViewModel();
            rentViewModel.RetnBooks = new ObservableCollection<RentEntity>(App.Db.RentRepository.GetAll());
            DataContext = rentViewModel;
        }

    }
}
