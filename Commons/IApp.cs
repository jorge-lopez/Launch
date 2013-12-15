using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public interface IApp
    {
        string Desarrollador { get; }
        string Nombre { get; }
        DateTime FechaPublicada { get; }
        string Categoria { get; }
        string Descripcion { get; }
        byte[] Imagen { get; }
    }
}
