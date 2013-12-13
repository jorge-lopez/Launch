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
    /// Interaction logic for Principal.xaml
    /// </summary>
    public partial class Principal //: Window
    {
        private string _correo;
        public Principal(string Correo)
        {
            InitializeComponent();
            _correo = Correo;
            this.DataContext = new PrincipalControles(Correo);
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToHorizontalOffset(scv.HorizontalOffset - (e.Delta *0.125));
            e.Handled = true;            
        }

        private void btn_Nombre_Click(object sender, RoutedEventArgs e)
        {
            Perfil p = new Perfil(_correo);
            p.Show();
            this.Close();

        }

        private void btn_busqueda_Click(object sender, RoutedEventArgs e)
        {
            //look for something
        }

        private void btn_principal_Click(object sender, RoutedEventArgs e)
        {
            Principal p = new Principal(_correo);
            p.Show();
            this.Close();
        }
        

    }
}
