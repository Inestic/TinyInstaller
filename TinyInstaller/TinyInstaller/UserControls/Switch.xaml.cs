using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TinyInstaller.UserControls
{
    /// <summary>
    /// Логика взаимодействия для Switch.xaml
    /// </summary>
    public partial class Switch : UserControl
    {
        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(Switch), new PropertyMetadata(default));

        public Switch()
        {
            InitializeComponent();
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        private void Switch_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => Command?.Execute(DataContext);
    }
}