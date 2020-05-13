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
    /// Interaction logic for EmployeeAdd.xaml
    /// </summary>
    public partial class EmployeeAdd : Window
    {
        public EmployeeAdd()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    db.Employees.Add(new Employee
                    {
                        Name = NameTextBox.Text,
                        SecondName = SecondNameTextBox.Text,
                        PositionId = comboBox.SelectedIndex + 1
                    });
                    db.SaveChanges();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            Close();
        }
    }
}
