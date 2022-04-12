using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TinyInstaller.UserControls
{
    /// <summary>
    /// Логика взаимодействия для HyperLink.xaml
    /// </summary>
    public partial class HyperLink : UserControl
    {
        // Using a DependencyProperty as the backing store for CanExecute.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanExecuteProperty =
            DependencyProperty.Register("CanExecute", typeof(bool), typeof(HyperLink), new PropertyMetadata(default));

        // Using a DependencyProperty as the backing store for CommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(HyperLink), new PropertyMetadata(default));

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(HyperLink), new PropertyMetadata(default));

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(HyperLink), new PropertyMetadata(default));

        public HyperLink()
        {
            InitializeComponent();
        }

        public bool CanExecute
        {
            get { return (bool)GetValue(CanExecuteProperty); }
            set { SetValue(CanExecuteProperty, value); }
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

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
    }
}