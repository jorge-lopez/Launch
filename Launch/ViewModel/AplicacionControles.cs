using BuisenessLogic;
using Commons;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Launch
{
    class AplicacionControles
    {
        private IUsuario UsuarioEnSesion;
        private Aplicaciones AplicacionEnVentana;

        public string NombreCompleto { get; private set; }
        public string Correo { get; private set; }
        public string NombreApp { get; private set; }
        public string Desarrollador { get; private set; }
        public string FechaPublicada { get; private set; }
        public string Descripcion { get; private set; }
        public string Categoria { get; private set; }
        public BitmapImage ImagenApp { get; private set; }

        
        public AplicacionControles(IUsuario Usuario, string NombreApp)
        {
            //Usuario en Sesion
            UsuarioEnSesion = Usuario;
            NombreCompleto = UsuarioEnSesion.Nombre + " " + UsuarioEnSesion.Apellido;
            this.Correo = UsuarioEnSesion.Correo;

            //Aplicacion en cuestion
            AplicacionEnVentana = new Aplicaciones(NombreApp);
            
            this.Desarrollador = AplicacionEnVentana.Desarrollador;
            this.NombreApp = AplicacionEnVentana.Nombre;
            this.FechaPublicada = AplicacionEnVentana.FechaPublicada;
            this.Descripcion = AplicacionEnVentana.Descripcion;
            this.Categoria = AplicacionEnVentana.Categoria;

            this.ImagenApp = ObtenerImagen(this.NombreApp);            
        }


        private static BitmapImage ObtenerImagen(string NombreApp)
        {
            byte[] laImagen = Aplicaciones.ObtenerImagen(NombreApp);
            var image = new BitmapImage();
            using (var mem = new MemoryStream(laImagen))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

        
    }
}
