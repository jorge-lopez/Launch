using Buiseness_Logic.LaunchServices;
using Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisenessLogic
{
    public class Aplicaciones : IApp
    {
        public string Desarrollador { get; private set; }
        public string Nombre { get; private set; }        
        public string FechaPublicada { get; private set; }
        public string Categoria { get; private set; }
        public string Descripcion { get; private set; }
        public byte[] Imagen { get; private set; }

        public Aplicaciones(string IdApp)
        {            
            int i = int.Parse(IdApp);
            IList<string> Propiedades = ObtenerAppInfo(i);
            this.Desarrollador = Propiedades[0];
            this.Nombre = Propiedades[1];
            this.FechaPublicada = Propiedades[2];
            this.Categoria = Propiedades[3];
            this.Descripcion = Propiedades[4];
            
        }        
        public static bool Publicar(string CorreoDesarrollador, string NombreApp, string Categoria, string Descripcion, byte[] Imagen)
        {
            using (ServiceClient sc = new ServiceClient())
            {
                return sc.AgregarApp(CorreoDesarrollador, NombreApp, Descripcion, Categoria, Imagen);                
            }
        }
        public static byte[] ObtenerImagen(string Nombre)
        {
            using (ServiceClient sc = new ServiceClient())
            {
                return sc.ObtenerImagenApp(Nombre);
            }
        }


        public static IList<IList<string>> ObtenerAppsSuscripcion()
        {
            using (ServiceClient SCliente = new ServiceClient())
            {
                return SCliente.ObtenerAppsSuscripcion();
            }
        }
        public static IList<IList<string>> ObtenerAppsRecientes()
        {
            using (ServiceClient SCliente = new ServiceClient())
            {
                return SCliente.ObtenerAppsRecientes();
            }
        }
        private IList<string> ObtenerAppInfo(int IdApp)
        {
            using (ServiceClient SCliente = new ServiceClient())
            {
                
                return SCliente.ObtenerAppInfo(IdApp);
            }
        }

    }
}
