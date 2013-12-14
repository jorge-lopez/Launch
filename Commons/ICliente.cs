using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public interface ICliente
    {
        string Nombre { get; }
        string Apellido { get; }
        string Correo { get; }
        string Contrasegna { get; }
        

    }
}
