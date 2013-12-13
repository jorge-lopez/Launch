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
    /// Interaction logic for Perfil.xaml
    /// </summary>
    public partial class Perfil
    {
        string _correo;
        public Perfil(string Correo)
        {
            InitializeComponent(); 
            _correo = Correo;
            this.DataContext = new PerfilControles(Correo);
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToHorizontalOffset(scv.HorizontalOffset - (e.Delta * 0.125));
            e.Handled = true;
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
