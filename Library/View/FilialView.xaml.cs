using Library.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;
namespace Library.View
{
    /// <summary>
    /// Interaction logic for FilialView.xaml
    /// </summary>
    public partial class FilialView : Window
    {
        public FilialView()
        {
            InitializeComponent();

            FilialViewModel filialViewModel = new FilialViewModel();
            filialViewModel.Filials = new ObservableCollection<Entity.FilialEntity>();
            DataContext = filialViewModel;
        }
    }
}
