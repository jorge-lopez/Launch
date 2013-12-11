using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

namespace Services
{
    [ServiceContract]
    public interface IUsuario
    {
        string Nombre { get; }
        string Apellido { get; }
        string Correo { get; }
        string Contrasegna { get; }
        [OperationContract]
        string RegresarNombre();
    }
}
