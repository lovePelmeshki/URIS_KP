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
    /// Interaction logic for DetectorOverviewWindow.xaml
    /// </summary>
    public partial class DetectorOverviewWindow : Window
    {
        Detector selectedDetector;
        public DetectorOverviewWindow()
        {
            InitializeComponent();
        }
        
        public DetectorOverviewWindow(Detector detector, bool isEditable)
        {
            selectedDetector = detector;
            InitializeComponent();
            button.IsEnabled = isEditable;
            DataContext = detector;
            idTextBox.Text = detector.Id.ToString();
            checkDatePicker.Text = detector.CheckDate.ToString();
            installDatePicker.Text = detector.InstallationDate.ToString();
            comboBox.Text = detector.Status;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    selectedDetector.Id = int.Parse(idTextBox.Text);
                    selectedDetector.CheckDate = DateTime.Parse(checkDatePicker.Text);
                    selectedDetector.InstallationDate = DateTime.Parse(installDatePicker.Text);
                    selectedDetector.Status = comboBox.Text;
                    if(checkBox.IsChecked == true)
                    {
                        selectedDetector.Status = "Готов к работе";
                        selectedDetector.PlaceId = 2;
                    }
                    db.Detectors.Add(selectedDetector);
                    db.Entry(selectedDetector).State = System.Data.Entity.EntityState.Modified;
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
