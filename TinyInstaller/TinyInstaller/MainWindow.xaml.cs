using System.Windows;
using TinyInstaller.Helpers;
using TinyInstaller.ViewModel;

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

        private void InitializeViewModel()
        {
            var viewModel = new VM(mainWindow: this, localizationHelper: new LocalizationHelper(), testsHelper: new StartupTestsHelper());
            DataContext = viewModel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) => InitializeViewModel();

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
        }
    }
}