﻿using Library.ViewModel;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for RentUserControl.xaml
    /// </summary>
    public partial class RentUserControl : UserControl
    {
        public RentUserControl(BookViewModel bookViewModel)
        {
            RentViewModel rentViewModel = new RentViewModel();
            rentViewModel.CurrentRentBook.BookId = bookViewModel.SelectBook;
            rentViewModel.CurrentRentBook.RealDate= DateTime.Now;
            DataContext = rentViewModel;
            InitializeComponent();
        }
    }
}
