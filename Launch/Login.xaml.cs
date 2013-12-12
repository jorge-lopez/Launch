using BuisenessLogic;
using MahApps.Metro.Controls;
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

namespace Launch
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login// : MetroWindow
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Register r = new Register();
            r.ShowDialog();

        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            bool LoginExitoso = Cliente.Login(txtBox_correo.Text, pwdBox_contrasegna.Password);
            if (LoginExitoso)
            {
                Principal p = new Principal(txtBox_correo.Text);
                p.Show();
                this.Close();
            }
            else
                MessageBox.Show("nope");
            
        }
    }
}
