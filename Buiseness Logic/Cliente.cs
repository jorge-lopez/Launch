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
                return DummyTest.RegresarNombre(_correo);
            }
            private set
            {
                _nombre = value;
                OnNotifyPropertyChanged("Nombre");
            }
        }
        public string Apellido { get; set; }
        public string Correo 
        { 
            get{ return _correo;}            
            private set
            {
                _correo = value;
                OnNotifyPropertyChanged("Corrreo");
            }
        }
        public string Contrasegna { get; set; }
        //List<Aplicaciones> appsInstaladas = new List<Aplicaciones>();

        public Cliente(string correo)
        {
            _correo = correo;
        }
        
        public static bool Login (string correo, string contrasegna)
        {
            bool b = SUsuario.Existe(correo, contrasegna);            
            return b;
        }
        
        public static void Registrar(IUsuario cliente)
        {
            try
            {
                SUsuario.Registrar(cliente);
            }
            catch(Exception ex)
            {
                string Error = ex.Message;
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
