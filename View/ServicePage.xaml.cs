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

namespace URIS_KP.View
{
    /// <summary>
    /// Interaction logic for ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        public ServicePage()
        {
            InitializeComponent();
            Refresh();
        }

        private void Refresh()
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var services = from serv in db.Services
                               join emp in db.Employees on serv.EmployeeId equals emp.Id
                               join detec in db.Detectors on serv.DetectorId equals detec.Id
                               join pls in db.Places on detec.PlaceId equals pls.Id
                               join loc in db.Locations on pls.LocationId equals loc.Id
                               select new
                               {
                                   serv.Id,
                                   serv.Type,
                                   loc.Name,
                                   serv.ServiceDate,
                                   serv.NextServiceDate,
                                   serv.DetectorId,
                                   Employee = emp.SecondName
                               };
                dataGridServicePage.ItemsSource = services.ToList();
            }

        }

        private void buttonAddNewService_Click(object sender, RoutedEventArgs e)
        {
            ServiceAddWindow serviceAddWindow = new ServiceAddWindow();
            serviceAddWindow.Show();
        }
    }
}
