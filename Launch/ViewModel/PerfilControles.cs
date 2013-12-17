using BuisenessLogic;
using Commons;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Launch
{
    class PerfilControles
    {
        private static Cliente UsuarioEnSesion;

        public string NombreCompleto { get; private set; }
        public string Correo { get; private set; }
        public IEnumerable StackAppsCompradas { get; private set; }

        
        public PerfilControles(IUsuario Cliente)
        {
            UsuarioEnSesion = new Cliente(Cliente.Correo);            
            NombreCompleto = UsuarioEnSesion.Nombre + " " + UsuarioEnSesion.Apellido;
            Correo = UsuarioEnSesion.Correo;
            StackAppsCompradas = new List<StackPanel>();
            Generar();
        }

        private void Generar()
        {
            IList<StackPanel> AppsCompradas = new List<StackPanel>();            

            GenerarAppsRecientes(AppsCompradas);

            StackAppsCompradas = AppsCompradas;
        }

        private static void GenerarAppsRecientes(IList<StackPanel> AppStack)
        {

            IList<IList<string>> lasApps = UsuarioEnSesion.ObtenerAppsCompradas();

            foreach (var app in lasApps)
            {
               
                //Imagen Applicacion
                Image img = new Image();
                img.Name = "App_" + app[0];
                img.Source = ObtenerImagen(app[1]);  //Aqui va el metodo para la imagen
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
                btn.Name = "App_" + app[0];
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
            //Button btn = (Button)sender;
            //var s = btn.Name.Split('_');
            //Aplicacion a = new Aplicacion(UsuarioEnSesion, s[1]);
            //a.Show();
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
