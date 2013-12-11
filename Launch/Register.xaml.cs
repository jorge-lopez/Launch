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
using BuisenessLogic;


namespace Launch
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Register
    {
        Validacion v = new Validacion();
        public Register()
        {            
            InitializeComponent();
            rdoBtn_usuario.IsChecked = true;
        }

        private void rdoBtn_usuario_Checked(object sender, RoutedEventArgs e)
        {
            rdoBtn_usuario.Background = new SolidColorBrush( Color.FromArgb(100,227,145,44));
            rdoBtn_desarrollador.Background = null;
        }

        private void rdoBtn_desarrollador_Checked(object sender, RoutedEventArgs e)
        {
            rdoBtn_desarrollador.Background = new SolidColorBrush(Color.FromArgb(100, 227, 145, 44));
            rdoBtn_usuario.Background = null;
        }

        private void txtBox_nombre_LostFocus(object sender, RoutedEventArgs e)
        {

            if (v.EsValidoNombre(txtBox_nombre.Text))
                lbl_nombre_error.Visibility = System.Windows.Visibility.Hidden;
            else
                lbl_nombre_error.Visibility = System.Windows.Visibility.Visible;
            ActivarRegistro();
        }

        private void txtBox_apellido_LostFocus(object sender, RoutedEventArgs e)
        {
            if (v.EsValidoApellido(txtBox_apellido.Text))
                lbl_apellido_error.Visibility = System.Windows.Visibility.Hidden;
            else
                lbl_apellido_error.Visibility = System.Windows.Visibility.Visible;
            ActivarRegistro();
        }

        private void txtBox_correo_LostFocus(object sender, RoutedEventArgs e)
        {            
            if(v.EsValidoCorreo(txtBox_correo.Text))
                lbl_correo_error.Visibility = System.Windows.Visibility.Hidden;
            else
                lbl_correo_error.Visibility = System.Windows.Visibility.Visible;
            ActivarRegistro();
        }

        private void pwdBox_contrasegna_LostFocus(object sender, RoutedEventArgs e)
        {
            if(v.EsValidaContrasegna(pwdBox_contrasegna.Password))
                lbl_contrasegna_error.Visibility = System.Windows.Visibility.Hidden;
            else
                lbl_contrasegna_error.Visibility = System.Windows.Visibility.Visible;
            ActivarRegistro();
        }

        private void pwdBox_verificaContrasegna_LostFocus(object sender, RoutedEventArgs e)
        {
            if (v.CoincideContrasegna(pwdBox_contrasegna.Password, pwdBox_verificaContrasegna.Password))
                lbl_verificaContrasegna_error.Visibility = System.Windows.Visibility.Hidden;
            else
                lbl_verificaContrasegna_error.Visibility = System.Windows.Visibility.Visible;

            ActivarRegistro();
        }

        private void ActivarRegistro()
        {
            if (v.TodoEsValido())
                btn_registrar.IsEnabled = true;
        }
    }
}
