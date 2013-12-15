using Commons;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Launch.ViewModel
{
    class PerfilDesarrolladorControles
    {
        private static IUsuario UsuarioEnSesion;

        public string NombreCompleto { get; private set; }
        public string Correo { get; private set; }
        public IEnumerable StackAppsPublicadas { get; private set; }


        public PerfilDesarrolladorControles(IUsuario Cliente)
        {
            UsuarioEnSesion = Cliente;
            NombreCompleto = UsuarioEnSesion.Nombre + " " + UsuarioEnSesion.Apellido;
            StackAppsPublicadas = new List<StackPanel>();
            Generar();
        }
        

        private void Generar()
        {
            IList<StackPanel> AppsCompradas = new List<StackPanel>();            

            GenerarAppsRecientes(AppsCompradas);

            StackAppsPublicadas = AppsCompradas;
        }

        private static void GenerarAppsRecientes(IList<StackPanel> AppStack)
        {
            int st = 10;
            for (int i = 0; i < st; i++)
            {

                //Imagen Applicacion
                Image img = new Image();
                img.Source = new BitmapImage(new Uri("/Launch;component/Imagenes/Launch Corp..png", UriKind.Relative));  //Aqui va el metodo para la imagen
                img.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                img.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                img.Height = 89;
                img.Width = 74;

                //Label aplicacion Nombre
                Label lbl = new Label();
                lbl.Content = "Nuevas"; //Aqui va el metodo para obtener el Nombre de la aplicacion
                lbl.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;


                //Boton Instalar                 
                Button btn = new Button();
                btn.Name = "SuperApp";
                btn.Content = "Correr";
                btn.MaxWidth = 90;
                btn.BorderBrush = Brushes.Black;    
                btn.Background = null;
                btn.Click += btn_Click;

                

                StackPanel sp = new StackPanel();
                sp.Orientation = Orientation.Vertical;
                sp.MinWidth = 150;

                sp.Children.Add(img);
                sp.Children.Add(lbl);
                sp.Children.Add(btn);


                AppStack.Add(sp);
            }
        }

        static void btn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
            Button btn = (Button)sender;            
            string s = btn.Name;            
            Aplicacion a = new Aplicacion(UsuarioEnSesion, s);
            a.Show();

            //Window w = (Window)sender;
            //w.Close();
            //e.Handled = true;
        }
        
    }
}
