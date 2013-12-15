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
    public partial class Principal
    {
        private IUsuario _cliente;
        public Principal(IUsuario Cliente)
        {
            InitializeComponent();
            _cliente = Cliente;
            this.DataContext = new PrincipalControles(Cliente);
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToHorizontalOffset(scv.HorizontalOffset - (e.Delta *0.125));
            e.Handled = true;            
        }

        private void btn_Nombre_Click(object sender, RoutedEventArgs e)
        {
            Perfil p = new Perfil(_cliente);
            p.Show();
            this.Close();

        }

        private void btn_busqueda_Click(object sender, RoutedEventArgs e)
        {
            //look for something
        }

        private void btn_principal_Click(object sender, RoutedEventArgs e)
        {
            Principal p = new Principal(_cliente);
            p.Show();
            this.Close();
        }
        

    }
}
