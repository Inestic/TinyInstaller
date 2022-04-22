using System.Windows;
using System.Windows.Controls;

namespace TinyInstaller.UserControls
{
    /// <summary>
    /// Логика взаимодействия для LoadingIndicator.xaml
    /// </summary>
    public partial class LoadingIndicator : UserControl
    {
        // Using a DependencyProperty as the backing store for StartAnimation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StartAnimationProperty =
            DependencyProperty.Register("StartAnimation", typeof(bool), typeof(LoadingIndicator), new PropertyMetadata(default));

        public LoadingIndicator()
        {
            InitializeComponent();
        }

        public bool StartAnimation
        {
            get { return (bool)GetValue(StartAnimationProperty); }
            set { SetValue(StartAnimationProperty, value); }
        }
    }
}