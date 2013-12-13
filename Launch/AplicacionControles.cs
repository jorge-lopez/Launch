using BuisenessLogic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Launch
{
    class AplicacionControles: INotifyPropertyChanged
    {
        private Cliente ClienteEnSesion;
        private Aplicaciones AplicacionEnVentana;
        private string _nombreCompleto;
        private string _correo;
        private string _nombreApp;
        private string _desarrollador;
        private string _fechaPublicada;
        private string _descripcion;
        private byte[] _imagen;
        private IEnumerable _StackComentarios;
        
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
                return ClienteEnSesion.Correo;
            }
            private set
            {
                _correo = value;
                OnNotifyPropertyChanged("Correo");
            }
        }
        public string NombreApp
        {
            get
            {
                return AplicacionEnVentana.NombreApp;
            }
            private set
            {
                _nombreApp = value;
                OnNotifyPropertyChanged("NombreApp");
            }
        }
        public string Desarrollador
        {
            get
            {
                return AplicacionEnVentana.Desarrollador;
            }
            private set
            {
                _desarrollador = value;
                OnNotifyPropertyChanged("Desarrollador");
            }
        }
        public string FechaPublicada
        {
            get
            {
                return String.Format("{0}/{1}/{2}",
                    AplicacionEnVentana.FechaPublica.Day,
                    AplicacionEnVentana.FechaPublica.Month,
                    AplicacionEnVentana.FechaPublica.Year);
            }
            private set
            {
                _fechaPublicada = value;
                OnNotifyPropertyChanged("FechaPublicada");
            }
        }
        public string Descripcion
        {
            get
            {
                return AplicacionEnVentana.Descripcion;
            }
            private set
            {
                _descripcion = value;
                OnNotifyPropertyChanged("Descripcion");
            }
        }
        public byte[] Imagen
        {
            get
            {
                return AplicacionEnVentana.Imagen;
            }
            private set
            {
                _imagen = value;
                OnNotifyPropertyChanged("Imagen");
            }
        }

        public IEnumerable StackComentarios
        {
            get { return _StackComentarios; }
            set
            {
                _StackComentarios = value;
                OnNotifyPropertyChanged("StackComentarios");
            }
        }

        
        public AplicacionControles(string Correo, string NombreApp)
        {
            //Usuario en Sesion
            ClienteEnSesion = new Cliente(Correo);
            NombreCompleto = ClienteEnSesion.Nombre + " " + ClienteEnSesion.Apellido;

            //Aplicacion en cuestion
            AplicacionEnVentana = new Aplicaciones(NombreApp);            
            
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

            StackComentarios = AppsCompradas;
        }

        private static void GenerarAppsRecientes(IList<StackPanel> AppStack)
        {
            int st = 10;
            for (int i = 0; i < st; i++)
            {
                //Imagen Applicacion
                Image img = new Image();
                img.Source = new BitmapImage(new Uri("Imagenes/Launch Corp..png", UriKind.Relative));  //Aqui va el metodo para la imagen
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
                btn.Content = "Instalar";
                btn.MaxWidth = 90;
                btn.BorderBrush = Brushes.Black;
                btn.Background = null;

                

                StackPanel sp = new StackPanel();
                sp.Orientation = Orientation.Vertical;
                sp.MinWidth = 150;

                sp.Children.Add(img);
                sp.Children.Add(lbl);
                sp.Children.Add(btn);


                AppStack.Add(sp);
            }
        }       
        
    }
}
