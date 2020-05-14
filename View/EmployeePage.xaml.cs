    using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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

                var employees = from emp in db.Employees
                                join pos in db.Positions on emp.PositionId equals pos.Id
                                select new
                                {
                                    emp.Id,
                                    emp.Name,
                                    emp.SecondName,
                                    PositionId = pos.Id,
                                    Position = pos.Name
                                };
                dataGridEmployeePage.ItemsSource = employees.ToList();

            }




        }
        private Employee FindEmployeeById()
        {

            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    var selectedCell = dataGridEmployeePage.SelectedCells[0];
                    var cellContent = selectedCell.Column.GetCellContent(selectedCell.Item);
                    int selectedId = int.Parse((cellContent as TextBlock).Text);
                    var selectedEmployee = db.Employees.Where(emp => emp.Id == selectedId).Single();
                    return selectedEmployee;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }

            }



        }

        private void buttonAddNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeAdd employeeAddWindow = new EmployeeAdd();
            employeeAddWindow.Show();
        }

        private void MenuShowItem_Click(object sender, RoutedEventArgs e)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                //var selectedCell = dataGridEmployeePage.SelectedCells[0];
                //var cellContent = selectedCell.Column.GetCellContent(selectedCell.Item);
                // int selectedId = int.Parse((cellContent as TextBlock).Text);
                //var selectedEmployee = db.Employees.Where(emp => emp.Id == selectedId).Single();
                Employee selectedEmployee = FindEmployeeById();
                EmployeeOverview employeeOverview = new EmployeeOverview(selectedEmployee, false);
                employeeOverview.Show();


                ////int id = dataGridEmployeePage.SelectedIndex + 1; // Говновариант
                //int id = ((Employee)dataGridEmployeePage.SelectedItem).Id;
                //var selectedEmployee = db.Employees.Where(emp => emp.Id == id).Single();
                //EmployeeOverview eo = new EmployeeOverview(selectedEmployee, false);
                //eo.Show();
            }

        }

        private void MenuEditItem_Click(object sender, RoutedEventArgs e)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                Employee selectedEmployee = FindEmployeeById();
                EmployeeOverview employeeOverview = new EmployeeOverview(selectedEmployee, true);
                employeeOverview.Show();
            }
        }

        private void MenuDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    Employee selectedEmployee = FindEmployeeById();
                    db.Entry(selectedEmployee).State = System.Data.Entity.EntityState.Deleted;
                    db.Employees.Remove(selectedEmployee);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            Refresh();
        }

        private void Page_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Refresh();
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                if (search.Text.Equals(""))
                {
                    Refresh();
                }
                else
                {
                    var employees = from emp in db.Employees
                                    join pos in db.Positions on emp.PositionId equals pos.Id
                                    where emp.Name.ToLower().Contains(search.Text.ToLower())
                                    || emp.SecondName.ToLower().Contains(search.Text.ToLower())
                                    select new
                                    {
                                        emp.Id,
                                        emp.Name,
                                        emp.SecondName,
                                        PositionId = pos.Id,
                                        Position = pos.Name
                                    };
                    dataGridEmployeePage.ItemsSource = employees.ToList();
                }
            }
            //var employees = from emp in db.Employees
            //                join pos in db.Positions on emp.PositionId equals pos.Id
            //                select new
            //                {
            //                    emp.Id,
            //                    emp.Name,
            //                    emp.SecondName,
            //                    PositionId = pos.Id,
            //                    Position = pos.Name
            //                };

        }
    }
}

