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
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
            Refresh();
        }

        private void Refresh()
        {
            using (DataBaseContext db = new DataBaseContext())
            {
              //  dg.ItemsSource = db.Locations.ToList();
                dataGridLicaationPage.ItemsSource = db.Locations.ToList();
            }
        }

        private void buttonAddNewLocation_Click(object sender, RoutedEventArgs e)
        {
            LocationAddWindow locationAddWindow = new LocationAddWindow();
            locationAddWindow.Show();
        }

        private void Page_MouseEnter(object sender, MouseEventArgs e)
        {
            Refresh();
        }

        private void textBox_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                if (textBox_search.Text.Equals(""))
                {
                    Refresh();
                }else
                {
                    var locations = from loc in db.Locations
                                    where loc.Name.ToLower().Contains(textBox_search.Text.ToLower())
                                    select loc;
                    dataGridLicaationPage.ItemsSource = locations.ToList();
                }
            }

        }

        private void Delete_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    int id = ((Location)dataGridLicaationPage.SelectedItem).Id;
                    MessageBox.Show(id.ToString());
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }
    }
}
