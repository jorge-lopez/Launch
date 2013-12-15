using Buiseness_Logic;
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
    public partial class Login
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
              bool[] LoginExitoso = Usuario.Login(txtBox_correo.Text, pwdBox_contrasegna.Password);
                if (LoginExitoso[0])
                {
                    if (!LoginExitoso[1])
                    {
                        ///Es cliente
                        Cliente c = new Cliente(txtBox_correo.Text);
                        Principal p = new Principal(c);
                        p.Show();
                        this.Close();
                    }
                    else
                    {
                        ///Es desarrollador
                        Desarrollador d = new Desarrollador(txtBox_correo.Text);
                        Principal p = new Principal(d);
                        p.Show();
                        this.Close();
                    }
                }
                else
                    MessageBox.Show("Las credencials son incorrectas");
            
           
        }
    }
}
