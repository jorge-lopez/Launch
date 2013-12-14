using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Services;
using System.Data;
using System.ComponentModel;
using Commons;
using Buiseness_Logic.LaunchServices;

namespace BuisenessLogic
{
    public class Cliente : INotifyPropertyChanged, ICliente
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
                OnNotifyPropertyChanged("Apellido");
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
                OnNotifyPropertyChanged("Correo");
            }
        }
        public string Contrasegna
        {
            get { return _contrasegna; }
            private set
            {
                _contrasegna = value;
                OnNotifyPropertyChanged("Contrasegna");
            }
        }
        //List<Aplicaciones> appsInstaladas = new List<Aplicaciones>();


        public Cliente(string correo)
        {
            Correo = correo;
            using (ServiceClient SCliente = new ServiceClient())
            {
                var valores = SCliente.ClienteActivo(this);
                if (valores != null)
                {
                    Nombre = valores[0];
                    Apellido = valores[1];
                    Contrasegna = valores[3];
                }
            }
        }
        public Cliente(string Nombre, string Apellido, string Correo, string Contrasegna)
        {
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Correo = Correo;
            this.Contrasegna = Contrasegna;
        }
        public void Actualizar()
        {
            using (ServiceClient SCliente = new ServiceClient())
            {
                SCliente.ActualizarCustomer(this);
            }
        }
        public static bool Login(string correo, string contrasegna)
        {
            using (ServiceClient SCliente = new ServiceClient())
            {
                return SCliente.Login(correo, contrasegna);
            }
        }
        public static bool Registrar(string Nombre, string Apellido, string Correo, string Contrasegna)
        {
            using (ServiceClient SCliente = new ServiceClient())
            {
                if (String.IsNullOrEmpty(Nombre) || String.IsNullOrEmpty(Apellido) ||
                    String.IsNullOrEmpty(Correo) || String.IsNullOrEmpty(Contrasegna))
                    return false;

                Cliente c = new Cliente(Nombre, Apellido, Correo, Contrasegna);
                return SCliente.AgregarCustomer(c);
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
