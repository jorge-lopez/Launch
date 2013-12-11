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

    class ClienteControles : INotifyPropertyChanged
    {
        public ClienteControles()
        {

            StackAppsSuscripcion = new List<StackPanel>();
            StackAppsRecientes = new List<StackPanel>();
            
            Generate(null);
        }

        private IEnumerable _StackAppsSuscripcion;
        public IEnumerable StackAppsSuscripcion
        {
            get { return _StackAppsSuscripcion; }
            set
            {
                _StackAppsSuscripcion = value;
                OnNotifyPropertyChanged("StackAppsSuscripcion");
            }
        }

        private IEnumerable _StackAppsRecientes;
        public IEnumerable StackAppsRecientes
        {
            get { return _StackAppsRecientes; }
            set
            {
                _StackAppsRecientes = value;
                OnNotifyPropertyChanged("StackAppsRecientes");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnNotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private void Generate(object obj)
        {
            IList<StackPanel> AppsSuscripcion = new List<StackPanel>();
            IList<StackPanel> AppsRecientes = new List<StackPanel>();

            GenerarAppsRecientes(AppsRecientes);
            GenerarAppsRecientes(AppsSuscripcion);

            StackAppsSuscripcion = AppsSuscripcion;         
            StackAppsRecientes = AppsRecientes;
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


