using System.Windows;
using System.Windows.Controls;

namespace TinyInstaller.UserControls
{
    /// <summary>
    /// Логика взаимодействия для HelpPanel.xaml
    /// </summary>
    public partial class HelpPanel : UserControl
    {
        // Using a DependencyProperty as the backing store for DescriptionText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DescriptionTextProperty =
            DependencyProperty.Register("DescriptionText", typeof(string), typeof(HelpPanel), new PropertyMetadata(default));

        // Using a DependencyProperty as the backing store for HeaderText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderTextProperty =
            DependencyProperty.Register("HeaderText", typeof(string), typeof(HelpPanel), new PropertyMetadata(default));

        public HelpPanel()
        {
            InitializeComponent();
        }

        public string DescriptionText
        {
            get { return (string)GetValue(DescriptionTextProperty); }
            set { SetValue(DescriptionTextProperty, value); }
        }

        public string HeaderText
        {
            get { return (string)GetValue(HeaderTextProperty); }
            set { SetValue(HeaderTextProperty, value); }
        }
    }
}