using System.Windows;
using TinyInstaller.Helpers;

namespace TinyInstaller
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = CompositionRootHelper.CreateVM(mainWindow: this);
        }
    }
}