using Buiseness_Logic.LaunchServices;
using BuisenessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buiseness_Logic
{
    public abstract class Usuario
    {
        public static bool[] Login(string correo, string contrasegna)
        {
            using (ServiceClient SCliente = new ServiceClient())
            {
                return SCliente.Login(correo, contrasegna);
            }
        }
        public static bool Registrar(bool EsCliente, string Nombre, string Apellido, string Correo, string Contrasegna)
        {
            using (ServiceClient SCliente = new ServiceClient())
            {
                if (String.IsNullOrEmpty(Nombre) || String.IsNullOrEmpty(Apellido) ||
                    String.IsNullOrEmpty(Correo) || String.IsNullOrEmpty(Contrasegna))
                    return false;
                if(EsCliente)
                    return SCliente.AgregarCustomer(Nombre, Apellido, Correo, Contrasegna);
                return SCliente.AgregarDeveloper(Nombre, Apellido, Correo, Contrasegna);

            }
        }
    }
}
