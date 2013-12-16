using BuisenessLogic;
using Commons;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        private static Desarrollador UsuarioEnSesion;

        public string NombreCompleto { get; private set; }
        public string Correo { get { return UsuarioEnSesion.Correo; } }
        public IEnumerable StackAppsPublicadas { get; private set; }


        public PerfilDesarrolladorControles(IUsuario Cliente)
        {
            UsuarioEnSesion = new Desarrollador(null,null,Cliente.Correo,null);
            NombreCompleto = Cliente.Nombre + " " + Cliente.Apellido;
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

            IList<IList<string>> lasApps = UsuarioEnSesion.ObtenerPrimeros10Apps();
            
            foreach (var app in lasApps)
            {
                
                //Imagen Applicacion
                Image img = new Image();
                img.Source = ObtenerImagen(app[1]);
                img.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                img.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                img.Height = 89;
                img.Width = 74;

                //Label aplicacion Nombre
                Label lbl = new Label();
                lbl.Content = app[1]; //Aqui va el metodo para obtener el Nombre de la aplicacion
                lbl.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;


                //Boton Instalar                 
                Button btn = new Button();
                btn.Name = app[0];
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
        private static BitmapImage ObtenerImagen(string NombreApp)
        {
            byte[] laImagen = Aplicaciones.ObtenerImagen(NombreApp);
            var image = new BitmapImage();
            using (var mem = new MemoryStream(laImagen))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
        
    }
}
