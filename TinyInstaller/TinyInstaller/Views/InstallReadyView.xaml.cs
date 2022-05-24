using System.Windows.Controls;
using System.Windows.Data;
using TinyInstaller.Poco;

namespace TinyInstaller.Views
{
    /// <summary>
    /// Логика взаимодействия для InstallReadyView.xaml
    /// </summary>
    public partial class InstallReadyView : UserControl
    {
        public InstallReadyView()
        {
            InitializeComponent();
        }

        private void EvenPackagesSource_Filter(object sender, FilterEventArgs e) => e.Accepted = IsEven(e.Item as Package);

        private bool IsEven(Package package) => package.Id % 2 == 0;

        private void OddPackagesSource_Filter(object sender, FilterEventArgs e) => e.Accepted = !IsEven(e.Item as Package);
    }
}