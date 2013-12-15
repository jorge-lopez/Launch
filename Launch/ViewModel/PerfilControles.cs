using BuisenessLogic;
using Commons;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Launch
{
    class PerfilControles: INotifyPropertyChanged
    {
        private static IUsuario UsuarioEnSesion;
        private string _nombreCompleto;
        private string _correo;
        private IEnumerable _StackAppsCompradas;
        
        public string NombreCompleto
        {
            get
            {
                return _nombreCompleto;
            }
            private set
            {
                _nombreCompleto = value;
                OnNotifyPropertyChanged("NombreCompleto");
            }
        }
        public string Correo
        {
            get
            {
                return UsuarioEnSesion.Correo;
            }
            private set
            {
                _correo = value;
                OnNotifyPropertyChanged("Correo");
            }
        }        
        public IEnumerable StackAppsCompradas
        {
            get { return _StackAppsCompradas; }
            set
            {
                _StackAppsCompradas = value;
                OnNotifyPropertyChanged("StackAppsCompradas");
            }
        }

        
        public PerfilControles(IUsuario Cliente)
        {
            UsuarioEnSesion = Cliente;
            _nombreCompleto = UsuarioEnSesion.Nombre + " " + UsuarioEnSesion.Apellido;
            StackAppsCompradas = new List<StackPanel>();
            Generar();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnNotifyPropertyChanged(string propiedad)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }

        private void Generar()
        {
            IList<StackPanel> AppsCompradas = new List<StackPanel>();            

            GenerarAppsRecientes(AppsCompradas);

            StackAppsCompradas = AppsCompradas;
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
