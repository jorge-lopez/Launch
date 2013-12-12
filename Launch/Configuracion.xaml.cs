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
        ModeloRegistro Mreg;
        int _errors = 0;
        public Configuracion(string correo)
        {
            InitializeComponent();
            Mreg = new ModeloRegistro(correo);
            DataContext = Mreg;
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
            //update
            this.Close();
        }

        private void btn_regresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
