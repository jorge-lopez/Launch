using BuisenessLogic;
using Commons;
using Launch.ViewModel;
using MahApps.Metro.Controls;
using Microsoft.Win32;
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

namespace Launch.View
{
    /// <summary>
    /// Interaction logic for PublicarApp.xaml
    /// </summary>
    public partial class PublicarApp : MetroWindow
    {
        private int _errors = 0;
        IUsuario _dev;
        public PublicarApp(IUsuario Desarrollador)
        {
            InitializeComponent();
            _dev = Desarrollador;
            this.DataContext = new ModeloPublicarApp();
        }
        private void btn_publicar_Click(object sender, RoutedEventArgs e)
        {
            if (Aplicaciones.Registrar(_dev.Correo, txtBox_nombre.Text, DateTime.Today, txtBox_categoria.Text, txtBox_descripcion.Text, null))
                MessageBox.Show("Aplicacion publicada con exito");
        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _errors++;
            else
                _errors--;

            if (_errors == 0)
                btn_publicar.IsEnabled = true;
            else
                btn_publicar.IsEnabled = false;
        }

        private void btn_regresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void btn_imagen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.png)|*.png|All files (*.*)|*.*";
            //ofd.InitialDirectory = @"C:\";
            ofd.Title = "Please select an image file to encrypt.";
            ofd.ShowDialog();
        
        }        
    }
}
