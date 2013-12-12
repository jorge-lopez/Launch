﻿using BuisenessLogic;
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

    class PrincipalControles : INotifyPropertyChanged
    {
        private Cliente ClienteEnSesion;
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
                return ClienteEnSesion.Correo;
            }
            private set
            {
                _correo = value;
                OnNotifyPropertyChanged("Nombre");
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

        public PrincipalControles(string correo)
        {
            ClienteEnSesion = new Cliente(correo);
            _nombreCompleto = ClienteEnSesion.Nombre + " " + ClienteEnSesion.Apellido;
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
            MessageBox.Show("Instalar app ?");
        }
        
    }
}


