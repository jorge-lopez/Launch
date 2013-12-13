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
    /// Interaction logic for Applicacion.xaml
    /// </summary>
    public partial class Aplicacion 
    {
        string _correo;
        public Aplicacion(string Correo, string NombreApp)
        {
            InitializeComponent();
            _correo = Correo;
            this.DataContext = new AplicacionControles(Correo, NombreApp);
        }

        private void btn_Nombre_Click(object sender, RoutedEventArgs e)
        {
            Configuracion c = new Configuracion(_correo);
            c.ShowDialog();
        }


        private void btn_principal_Click(object sender, RoutedEventArgs e)
        {
            Principal p = new Principal(_correo);
            p.Show();
            this.Close();
        }
        private void btn_busqueda_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
