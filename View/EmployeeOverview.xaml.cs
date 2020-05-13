using System;
using System.Windows;

namespace URIS_KP.View
{
    /// <summary>
    /// Interaction logic for EmployeeOverview.xaml
    /// </summary>
    public partial class EmployeeOverview : Window
    {
        Employee selectedEmployee;
        public EmployeeOverview()
        {
            InitializeComponent();
        }

        public EmployeeOverview(Employee employee, bool IsEditable)
        {
            selectedEmployee = employee;
            InitializeComponent();
            button.IsEnabled = IsEditable;
            DataContext = employee;
            IdTextBox.Text = employee.Id.ToString();
            SecondNameTextBox.Text = employee.SecondName;
            NameTextBox.Text = employee.Name;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    selectedEmployee.Id = int.Parse(IdTextBox.Text);
                    selectedEmployee.Name = NameTextBox.Text;
                    selectedEmployee.SecondName = SecondNameTextBox.Text;
                    selectedEmployee.PositionId = comboBox.SelectedIndex + 1;
                    db.Employees.Add(selectedEmployee);
                    db.Entry(selectedEmployee).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            Close();

        }
    }
}
