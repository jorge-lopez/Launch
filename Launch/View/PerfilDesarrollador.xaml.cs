using Commons;
using Launch.ViewModel;
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

namespace Launch.View
{
    /// <summary>
    /// Interaction logic for PerfilDesarrollador.xaml
    /// </summary>
    public partial class PerfilDesarrollador 
    {
        private IUsuario _usuario;
        public PerfilDesarrollador(IUsuario Usuario)
        {
            _usuario = Usuario;
            InitializeComponent(); 
            this.DataContext = new PerfilDesarrolladorControles(Usuario);
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToHorizontalOffset(scv.HorizontalOffset - (e.Delta * 0.125));
            e.Handled = true;
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

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Cerrar Sesion?", "Cerrar Sesion", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Login l = new Login();
                l.Show();
                this.Close();
            }
        }
    }
}
