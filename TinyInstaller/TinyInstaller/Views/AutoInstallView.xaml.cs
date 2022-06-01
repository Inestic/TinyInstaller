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
        private uint packagesCounter = 1;

        public AutoInstallView()
        {
            InitializeComponent();
        }

        private void EvenPackagesSource_Filter(object sender, FilterEventArgs e) => e.Accepted = IsEven(e.Item as Package);

        private bool IsEven(Package package) => packagesCounter++ % 2 == 0;

        private void OddPackagesSource_Filter(object sender, FilterEventArgs e) => e.Accepted = !IsEven(e.Item as Package);
    }
}