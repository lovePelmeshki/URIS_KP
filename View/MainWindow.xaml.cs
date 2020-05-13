using System.Windows;
using URIS_KP.View;
using URIS_KP.ViewModel;
using MahApps.Metro.Controls;

namespace URIS_KP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void Button_Main_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new MainPage();
        }

        private void Button_Request_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Page1();
        }

        private void Button_Locations_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Page2();
        }

        private void Button_Detectors_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new DetectorPage();
        }

        private void Button_Service_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ServicePage();
        }

        private void Button_Employees_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new EmployeePage();
        }
    }
}
