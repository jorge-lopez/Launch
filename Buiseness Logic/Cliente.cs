using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Services;
using System.Data;
using Services;

namespace BuisenessLogic
{
    public class Cliente //:IUsuario
    //public class Cliente : DummyTest
    {
        
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Contrasegna { get; set; }
        //List<Aplicaciones> appsInstaladas = new List<Aplicaciones>();

        public Cliente(string Nombre, string Correo)
        {            
            //this.Nombre = Nombre;
            //this.Correo = Correo;
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


        public void Instalar()
        { }
        public void ComprarMembresia()
        { }
        public void Buscar()
        { }
        public void Remover()
        { }

        public string RegresarNombre()
        {
            return null;
        }

        

    }
}
