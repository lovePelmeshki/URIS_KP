
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace URIS_KP.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged ([CallerMemberName]string prop ="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        private int _nums;
        public int Nums
        {
            get { return _nums; }
            set
            {
                _nums = value;
                OnPropertyChanged();
            }
        }
        public MainWindowViewModel()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Task.Delay(200).Wait();
                    Nums++;
                }
            });
        }
    }
}
