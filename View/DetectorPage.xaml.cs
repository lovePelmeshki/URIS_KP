using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace URIS_KP.View
{
    /// <summary>
    /// Interaction logic for DetectorPage.xaml
    /// </summary>
    public partial class DetectorPage : Page
    {
        public DetectorPage()
        {
            InitializeComponent();
            Refresh();
        }



        private void buttonAddNewDetector_Click(object sender, RoutedEventArgs e)
        {
            DetectorAddWindow detectorAddWindow = new DetectorAddWindow();
            detectorAddWindow.Show();
        }
        private void Refresh()
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var detectors = from detec in db.Detectors
                                join place in db.Places on detec.PlaceId equals place.Id
                                join loc in db.Locations on place.LocationId equals loc.Id
                                select new
                                {
                                    detec.Id,
                                    detec.CheckDate,
                                    detec.InstallationDate,
                                    detec.Status,
                                    Location = loc.Name,
                                    Place = place.Name
                                };
                
                dataGridDetectorPage.ItemsSource = detectors.ToList();
            }
            
        }
    }
}
