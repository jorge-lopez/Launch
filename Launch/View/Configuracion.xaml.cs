using BuisenessLogic;
using Commons;
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
    /// Interaction logic for Configuracion.xaml
    /// </summary>
    public partial class Configuracion
    {
        int _errors = 0;
        private IUsuario _cliente;
        public Configuracion(IUsuario Cliente)
        {
            InitializeComponent();
            _cliente = Cliente;
            DataContext = new ModeloRegistro(Cliente); 
        }
        private void pwdBox_verificaContrasegna_LostFocus(object sender, RoutedEventArgs e)
        {
            if (pwdBox_contrasegna.Password == pwdBox_verificaContrasegna.Password)
                lbl_verificaContrasegna_error.Visibility = System.Windows.Visibility.Hidden;
            else
                lbl_verificaContrasegna_error.Visibility = System.Windows.Visibility.Visible;
        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _errors++;
            else
                _errors--;

            if (_errors == 0)
                btn_actualizar.IsEnabled = true;
            else
                btn_actualizar.IsEnabled = false;
        }

        private void btn_actualizar_Click(object sender, RoutedEventArgs e)
        {
            _cliente.Actualizar(txtBox_nombre.Text, txtBox_apellido.Text, pwdBox_contrasegna.Password);
            this.Close();
        }

        private void btn_regresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
