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
    /// Interaction logic for LocationAddWindow.xaml
    /// </summary>
    public partial class LocationAddWindow : Window
    {
        public LocationAddWindow()
        {
            InitializeComponent();
        }
 
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    db.Locations.Add(new Location()
                    {
                        Name = textBox.Text,
                        DistrictId = comboBox.SelectedIndex + 1
                    });
                    db.SaveChanges();
                    Close();
                } 
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
    }
}
