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
using System.Windows.Shapes;

namespace FinalCheck
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public delegate void mydeledate();
        public mydeledate confirmcloseform;
        public Login()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password == "123456" && NameTextBox.Text =="PE")
            {
                PasswordBox.Password = "";
                NameTextBox.Text = "";
                Setup p = new Setup();
                p.confirmcloseform = new Setup.mydeledate(closeform);
                p.Show();
            }
            else
            {
                txbl_status.Visibility = Visibility.Visible;

            }
            
        }
        public void closeform()
        {
            confirmcloseform?.Invoke();
            this.Close();
        }
    }
}
