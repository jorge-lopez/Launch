using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launch
{
    public abstract class Usuario
    {
        public string Nombre { get; set; }
        public string Correo { get; set;}

        public string Comentar() 
        { return null; }
    }
}
