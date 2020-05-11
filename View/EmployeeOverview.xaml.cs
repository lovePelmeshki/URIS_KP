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
using System.Windows.Shapes;

namespace URIS_KP.View
{
    /// <summary>
    /// Interaction logic for EmployeeOverview.xaml
    /// </summary>
    public partial class EmployeeOverview : Window
    {
        public EmployeeOverview()
        {
            InitializeComponent();
        }
        public EmployeeOverview(Employee employee, bool IsEditable)
        {
            InitializeComponent();
            DataContext = employee;
            IdTextBox.Text = employee.Id.ToString();
            SecondNameTextBox.Text = employee.SecondName;
            NameTextBox.Text = employee.Name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
