using Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Services
{
    [DataContract]
    public class ServiceCliente// : IUsuario
    {
        [DataMember]
        public string Nombre { get; private set; }
        [DataMember]
        public string Apellido { get; private set; }
        [DataMember]
        public string Correo { get; private set; }
        [DataMember]
        public string Contrasegna { get; private set; }
        //List<Aplicaciones> appsInstaladas = new List<Aplicaciones>();

        public ServiceCliente() {}
        public ServiceCliente(string Correo)
        {
            this.Correo = Correo;
            //using (ServiceClient SCliente = new ServiceClient())
            //{
            //    var valores = SCliente.ClienteActivo(this);
            //    if (valores != null)
            //    {
            //        Nombre = valores[0];
            //        Apellido = valores[1];
            //        Contrasegna = valores[3];
            //    }
            //}
        }
        public ServiceCliente(string Nombre, string Apellido, string Correo, string Contrasegna)
        {
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Correo = Correo;
            this.Contrasegna = Contrasegna;
        }

        
    }
}