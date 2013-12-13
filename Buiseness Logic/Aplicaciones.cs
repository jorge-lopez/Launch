using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisenessLogic
{
    public class Aplicaciones : INotifyPropertyChanged
    {
        private string _nombreApp;
        private string _desarrollador;
        private DateTime _fechaPublicada;
        private string _descripcion;
        private byte[] _imagen;
        public string NombreApp
        {
            get { return _nombreApp; }
            private set
            {
                _nombreApp = value;
                OnNotifyPropertyChanged("NombreApp");
            }
        }
        public string Desarrollador
        {
            get { return _desarrollador; }
            private set
            {
                _desarrollador = value;
                OnNotifyPropertyChanged("Desarrollador");
            }
        }
        public DateTime FechaPublica 
        {
            get
            {   return _fechaPublicada; }
            private set
            {
                _fechaPublicada = value;
                OnNotifyPropertyChanged("FechaPublica");
            }
        }
        public string Descripcion
        {
            get
            { return _descripcion; }
            private set
            {
                _descripcion = value;
                OnNotifyPropertyChanged("Descripcion");
            }
        }
        public byte[] Imagen
        {
            get
            { return _imagen; }
            private set
            {
                _imagen = value;
                OnNotifyPropertyChanged("Imagen");
            }
        }

        public Aplicaciones(string NombreApp)
        {
            this.NombreApp = NombreApp;
            this.Descripcion = "Aplicacion para para disfrutaren casa\nSiguiente semana habra updates ;D";
            this.FechaPublica = DateTime.Today;
            this.Desarrollador = "Manny y George";

        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnNotifyPropertyChanged(string propiedad)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }

    }
}
