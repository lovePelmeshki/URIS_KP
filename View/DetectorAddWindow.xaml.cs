using System;
using System.Windows;

namespace URIS_KP.View
{
    /// <summary>
    /// Interaction logic for DetectorAddWindow.xaml
    /// </summary>
    public partial class DetectorAddWindow : Window
    {
        public DetectorAddWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    db.Detectors.Add(new Detector
                    {
                        CheckDate = DateTime.Parse(checkDatePicker.Text),
                        InstallationDate = DateTime.Now,
                        Status = "На складе",
                        PlaceId = 2
                    });
                    db.SaveChanges();
                    Close();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

    }
}
