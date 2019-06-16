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
    /// Interaction logic for WorkerUserControl.xaml
    /// </summary>
    public partial class WorkerUserControl : UserControl
    {
        public WorkerUserControl()
        {
            InitializeComponent();
            WorkerViewModel workerViewModel = new WorkerViewModel();
            workerViewModel.Workers = new ObservableCollection<WorkerEntity>(App.Db.WorkerRepository.GetAll());
            workerViewModel.filials = new List<FilialEntity>(App.Db.BranchRepository.GetAll());
            DataContext = workerViewModel;
        }
    }
}
