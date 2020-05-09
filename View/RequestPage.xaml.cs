﻿using System;
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

namespace URIS_KP.View
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            Refresh();
        }

        private void Refresh()
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                dataGridRequestPage.ItemsSource = db.Requests.ToList();
            }

        }

        private void buttonAddNewRequest_Click(object sender, RoutedEventArgs e)
        {
            //open new window
        }
    }
}
