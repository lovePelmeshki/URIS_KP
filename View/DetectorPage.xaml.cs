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


        private Detector FindDetectorById()
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    var selectedCell = dataGrid.SelectedCells[0];
                    var cellContent = selectedCell.Column.GetCellContent(selectedCell.Item);
                    int selectedId = int.Parse((cellContent as TextBlock).Text);
                    var selectedDetector = db.Detectors.Where(emp => emp.Id == selectedId).Single();
                    return selectedDetector;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }

            }
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
                
                dataGrid.ItemsSource = detectors.ToList();
            }
            
        }

        private void Page_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Refresh();
        }

        private void MenuShowItem_Click(object sender, RoutedEventArgs e)
        {
            Detector detector = FindDetectorById();
            DetectorOverviewWindow detectorOverviewWindow = new DetectorOverviewWindow(detector, false);
            detectorOverviewWindow.Show();
        }

        private void MenuEditItem_Click(object sender, RoutedEventArgs e)
        {
            Detector detector = FindDetectorById();
            DetectorOverviewWindow detectorOverviewWindow = new DetectorOverviewWindow(detector, true);
            detectorOverviewWindow.Show();
        }

        private void MenuDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    Detector selectedDetector = FindDetectorById();
                    db.Entry(selectedDetector).State = System.Data.Entity.EntityState.Deleted;
                    db.Detectors.Remove(selectedDetector);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            Refresh();

        }
    }
}
