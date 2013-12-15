using Buiseness_Logic.LaunchServices;
using Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisenessLogic
{
    public class Desarrollador : IUsuario
    {
        
        public string Nombre{get;private set;}
        public string Apellido{get;private set;}
        public string Correo{get;private set;}
        public string Contrasegna{get;private set;}
        //List<Aplicaciones> appsInstaladas = new List<Aplicaciones>();

        public Desarrollador(string correo)
        {
            Correo = correo;
            using (ServiceClient SCliente = new ServiceClient())
            {
                var c = SCliente.DesarrolladorActivo(this.Correo);
                
                if (c!= null)
                {
                    this.Nombre = c[0];
                    this.Apellido = c[1];
                    this.Contrasegna = c[2];
                }
            }
        }
        public Desarrollador(string Nombre, string Apellido, string Correo, string Contrasegna)
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
                SCliente.ActualizarDeveloper(Nombre, Apellido, this.Correo, Contrasegna);
            }
        }
    }
}
