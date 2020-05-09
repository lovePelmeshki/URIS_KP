
using System.Windows.Controls;
using URIS_KP.View;
using URIS_KP.ViewModel;
using URIS_KP;
using System.Linq;

namespace URIS_KP.View
{
    /// <summary>
    /// Сюда будут подгружаться открытые заявки и просроченный техпроцесс.
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            DataContext = new DataBaseContext();
            InitializeComponent();
        }

        private void dataGridMainPage_Initialized(object sender, System.EventArgs e)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                dataGridMainPage.ItemsSource = db.Districts.ToList();
            }
        }
    }
}
