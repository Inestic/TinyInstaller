using System.Windows;
using System.Windows.Controls;

namespace TinyInstaller.UserControls
{
    /// <summary>
    /// Логика взаимодействия для Spinner.xaml
    /// </summary>
    public partial class Spinner : UserControl
    {
        // Using a DependencyProperty as the backing store for ShowAnimation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowAnimationProperty =
            DependencyProperty.Register("ShowAnimation", typeof(bool), typeof(Spinner), new PropertyMetadata(default));

        public Spinner()
        {
            InitializeComponent();
        }

        public bool ShowAnimation
        {
            get { return (bool)GetValue(ShowAnimationProperty); }
            set { SetValue(ShowAnimationProperty, value); }
        }
    }
}