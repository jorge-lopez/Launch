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
    /// Interaction logic for Applicacion.xaml
    /// </summary>
    public partial class Aplicacion 
    {
        private IUsuario _usuario;
        public Aplicacion(IUsuario Usuario, string IdApp)
        {
            InitializeComponent();
            _usuario = Usuario;
            this.DataContext = new AplicacionControles(Usuario, IdApp);
        }

        private void btn_Nombre_Click(object sender, RoutedEventArgs e)
        {
            Configuracion c = new Configuracion(_usuario);
            c.ShowDialog();
        }


        private void btn_principal_Click(object sender, RoutedEventArgs e)
        {
            Principal p = new Principal(_usuario);
            p.Show();
            this.Close();
        }
        private void btn_busqueda_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
