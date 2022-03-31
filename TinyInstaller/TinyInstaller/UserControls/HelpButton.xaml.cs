using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TinyInstaller.UserControls
{
    /// <summary>
    /// Логика взаимодействия для HelpButton.xaml
    /// </summary>
    public partial class HelpButton : UserControl
    {
        // Using a DependencyProperty as the backing store for CommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(HelpButton), new PropertyMetadata(default));

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(HelpButton), new PropertyMetadata(default));

        public HelpButton()
        {
            InitializeComponent();
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        private void ButtonClickStoryboard_Completed(object sender, System.EventArgs e) => Command?.Execute(CommandParameter);
    }
}