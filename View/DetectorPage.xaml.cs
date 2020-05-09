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
                dataGridDetectorPage.ItemsSource = db.Detectors.ToList();
            }
            
        }
    }
}
