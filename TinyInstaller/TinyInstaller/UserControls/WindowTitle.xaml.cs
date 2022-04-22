using System.Windows.Controls;
using System.Windows.Input;
using TinyInstaller.ViewModel;

namespace TinyInstaller.UserControls
{
    /// <summary>
    /// Логика взаимодействия для WindowTitle.xaml
    /// </summary>
    public partial class WindowTitle : UserControl
    {
        public WindowTitle()
        {
            InitializeComponent();
        }

        private void WindowTitle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                (DataContext as MainViewModel).MainWindow.DragMove();
        }
    }
}