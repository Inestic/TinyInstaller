using System.Windows.Controls;
using System.Windows.Data;
using TinyInstaller.Poco;

namespace TinyInstaller.Views
{
    /// <summary>
    /// Логика взаимодействия для AutoInstallView.xaml
    /// </summary>
    public partial class AutoInstallView : UserControl
    {
        private uint evenCounter = 1;
        private uint oddCounter = 1;

        public AutoInstallView()
        {
            InitializeComponent();
        }

        private void EvenPackagesSource_Filter(object sender, FilterEventArgs e) => e.Accepted = IsEven(e.Item as Package);

        private bool IsEven(Package package) => evenCounter++ % 2 == 0;

        private bool IsOdd(Package package) => oddCounter++ % 2 == 1;

        private void OddPackagesSource_Filter(object sender, FilterEventArgs e) => e.Accepted = IsOdd(e.Item as Package);
    }
}