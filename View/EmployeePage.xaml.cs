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
    /// Interaction logic for EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        public EmployeePage()
        {
            InitializeComponent();
            Refresh();
        }


        private void Refresh()
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                dataGridEmployeePage.ItemsSource = db.Employees.ToList();
            }

        }

        private void buttonAddNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeAddWindow employeeAddWindow = new EmployeeAddWindow();
            employeeAddWindow.Show();
        }
    }
}
