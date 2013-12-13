using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Services;
using System.Data;
using Services;
using System.ComponentModel;

namespace BuisenessLogic
{
    public class Cliente : INotifyPropertyChanged
    //public class Cliente : DummyTest
    {
        private string _nombre;
        private string _apellido;
        private string _correo;
        private string _contrasegna;
        public string Nombre
        {
            get
            {
                return _nombre;
            }
            private set
            {
                _nombre = value;
                OnNotifyPropertyChanged("Nombre");
            }
        }
        public string Apellido
        {
            get
            {
                return _apellido;
            }
            private set
            {
                _apellido = value;
                OnNotifyPropertyChanged("Nombre");
            }
        }
        public string Correo 
        { 
            get
            {
                return _correo;
            }            
            private set
            {
                _correo = value;
                OnNotifyPropertyChanged("Corrreo");
            }
        }
        public string Contrasegna 
        {
            get { return _contrasegna; }
            private set
            {
                _contrasegna = _nombre;
                OnNotifyPropertyChanged("Corrreo");
            }
        }
        //List<Aplicaciones> appsInstaladas = new List<Aplicaciones>();

        public Cliente(string correo)
        {
            _correo = correo;
            var valores = Service.ClienteActivo(Correo);
            if (valores != null)
            {
                Nombre = valores[0];
                Apellido = valores[1];
                Correo = valores[2];
                Contrasegna = valores[3];
            }
        }
        
        public static bool Login (string correo, string contrasegna)
        {
            bool b = Service.Login(correo, contrasegna);            
            return b;
        }

        public static bool Registrar(string Nombre, string Apellido, string Correo, string Contrasegna)
        {
            try
            {
                if (String.IsNullOrEmpty(Nombre) ||
                    String.IsNullOrEmpty(Apellido) ||
                    String.IsNullOrEmpty(Correo) ||
                    String.IsNullOrEmpty(Contrasegna) )
                    throw new ArgumentNullException();

                //if (DummyTest.Registrar(Nombre, Apellido, Correo, Contrasegna))                                    
                //    return true;

                Service.AgregarCustomer(Nombre, Apellido, Correo, Contrasegna);
                return true;
            }
            catch(Exception ex)
            {
                string Error = ex.Message;
                return false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnNotifyPropertyChanged(string propiedad)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }
        public void Instalar()
        { }
        public void ComprarMembresia()
        { }
        public void Buscar()
        { }
        public void Remover()
        { }

        

    }
}
