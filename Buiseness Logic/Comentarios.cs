using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisenessLogic
{
    class Comentarios
    {
        public string Usuario { get; private set; }
        public string Correo{ get; private set; }
        public DateTime Fecha { get; private set; }
        public string Contenido { get; private set; }

        public Comentarios(string Comentario)
        {
            //this.Usuario = Usuario.Nombre;
            //this.Correo = Usuario.Correo;
            this.Contenido = Comentario;
            this.Fecha = DateTime.Today;
        }
        public Comentarios(string Usario, string Correo, string Comentario)
        {
            this.Usuario = Usuario;
            this.Correo = Correo;
            this.Contenido = Comentario;
            this.Fecha = DateTime.Today;
        }
        
    }
}
