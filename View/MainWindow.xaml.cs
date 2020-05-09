using System.Windows;
using URIS_KP.View;
using URIS_KP.ViewModel;

namespace URIS_KP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Page1_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Page1();
        }
        private void Button_Page2_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Page2();
        }

    }
}
