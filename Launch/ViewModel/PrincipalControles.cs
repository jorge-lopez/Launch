﻿using BuisenessLogic;
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
 class PrincipalControles : INotifyPropertyChanged
    {
        private static IUsuario UsuarioEnSesion;
        private string _nombreCompleto;
        private string _correo;
        private IEnumerable _StackAppsSuscripcion;
        private IEnumerable _StackAppsRecientes;
        
        public string NombreCompleto
        {
            get
            {
                return _nombreCompleto;
            }
            private set
            {
                _nombreCompleto = value;
                OnNotifyPropertyChanged("Nombre");
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
        
        public IEnumerable StackAppsSuscripcion
        {
            get { return _StackAppsSuscripcion; }
            set
            {
                _StackAppsSuscripcion = value;
                OnNotifyPropertyChanged("StackAppsSuscripcion");
            }
        }

        
        public IEnumerable StackAppsRecientes
        {
            get { return _StackAppsRecientes; }
            set
            {
                _StackAppsRecientes = value;
                OnNotifyPropertyChanged("StackAppsRecientes");
            }
        }

        public PrincipalControles(IUsuario Cliente)
        {
            UsuarioEnSesion = Cliente;
            _nombreCompleto = UsuarioEnSesion.Nombre + " " + UsuarioEnSesion.Apellido;
            StackAppsSuscripcion = new List<StackPanel>();
            StackAppsRecientes = new List<StackPanel>();

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
            IList<StackPanel> AppsSuscripcion = new List<StackPanel>();
            IList<StackPanel> AppsRecientes = new List<StackPanel>();

            IList<IList<string>> lasApps;
            
            lasApps= Aplicaciones.ObtenerAppsRecientes();
            GenerarAppsRecientes(AppsRecientes,lasApps);
            lasApps = Aplicaciones.ObtenerAppsSuscripcion();
            GenerarAppsRecientes(AppsSuscripcion,lasApps);

            StackAppsSuscripcion = AppsSuscripcion;
            StackAppsRecientes = AppsRecientes;
        }

        private static void GenerarAppsRecientes(IList<StackPanel> AppStack, IList<IList<string>> lasApps)
        {
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
                btn.Content = "Instalar";
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
   


