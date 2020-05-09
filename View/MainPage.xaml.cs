
using System.Windows.Controls;
using URIS_KP.View;
using URIS_KP.ViewModel;
using URIS_KP;


namespace URIS_KP.View
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            DataContext = new DataBaseContext();
            InitializeComponent();
        }
    }
}
