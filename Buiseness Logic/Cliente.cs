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
    public class Cliente : INotifyPropertyChanged, IUsuario
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
                var c = SCliente.ClienteActivo(this.Correo);
                
                if (c!= null)
                {
                    this.Nombre = c[0];
                    this.Apellido = c[1];
                    this.Contrasegna = c[2];
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
        public void Actualizar(string Nombre, string Apellido, string Contrasegna)
        {
            using (ServiceClient SCliente = new ServiceClient())
            {
                SCliente.ActualizarCustomer(Nombre, Apellido, this.Correo, Contrasegna);
            }
        }
        public IList<IList<string>> ObtenerAppsCompradas()
        {
            using (ServiceClient SCliente = new ServiceClient())
            {
                return SCliente.ObtenerAppsComprados(this.Correo);
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

        public bool ComprarApp(int IdApp)
        {
            using (ServiceClient sc = new ServiceClient())
            {
                return sc.AgregarAppPurchasedbyId(IdApp, this.Correo);
            }
        }
        public bool ComprarApp(string NombreApp)
        {
            using (ServiceClient sc = new ServiceClient())
            {
                return sc.AgregarAppPurchasedbyName(NombreApp, this.Correo);
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
