using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankManagementSystem.View.Components
{
    /// <summary>
    /// Interaction logic for PassWordBoxControl.xaml
    /// </summary>
    public partial class PassWordBoxControl : UserControl
    {
        private static bool isPasswordChanging;

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password",typeof(string), typeof(PassWordBoxControl), new PropertyMetadata(string.Empty, PasswordPropertyChanged));

        private static void PasswordPropertyChanged(DependencyObject d,DependencyPropertyChangedEventArgs e)
        {
            if(d is PassWordBoxControl passwordBox)
            {
                isPasswordChanging = true;
                passwordBox.UpdatePassword();
                isPasswordChanging= false;
            }
        }

        private void UpdatePassword()
        {
            if (!isPasswordChanging)
                PasswordBox.Password = Password;
        }
        public PassWordBoxControl()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = PasswordBox.Password;
        }
    }
}
