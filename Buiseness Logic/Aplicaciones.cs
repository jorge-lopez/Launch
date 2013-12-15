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
        public DateTime FechaPublicada { get; private set; }
        public string Categoria { get; private set; }
        public string Descripcion { get; private set; }
        public byte[] Imagen { get; private set; }

        public Aplicaciones(string NombreApp)
        {
            this.Nombre = NombreApp;
            this.Descripcion = "Aplicacion para para disfrutaren casa\nSiguiente semana habra updates ;D";
            this.FechaPublicada = DateTime.Today;
            this.Desarrollador = "Manny y George";

        }
        public static bool Registrar(string CorreoDesarrollador, string NombreApp, DateTime FechaPublicada, string Categoria, string Descripcion, byte[] Foto)
        {
            using (ServiceClient sc = new ServiceClient())
            {
                //Que el servicio se encarge buscar el ID del Dev con el correo
                //Crear metodo AgregarPurchased
                //sc.AgregarAppPurchased();
                return false;
            }
        }

    }
}
