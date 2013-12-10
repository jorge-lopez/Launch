using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launch
{
    class Validacion
    {
        private bool _NombreValido = false;
        private bool _ApellidoValido = false;
        private bool _CorreoValido = false;
        private bool _ContrasegnaValido = false;
        private bool _ContrasegnaCoincide = false;


        public bool EsValidoNombre(string Nombre)
        {
            if (Nombre == "")
            {
                _NombreValido = true;
                return false;
            }
            else
            {
                _NombreValido = false;
                return true;
            }
        }
        public bool EsValidoApellido(string Nombre)
        {
            if (Nombre == "")
            {
                _ApellidoValido = true;
                return false;
            }
            else
            {
                _ApellidoValido = false;
                return true;
            }
        }
        public bool EsValidoCorreo(string Correo)
        {
            try
            {
                var cuerdas = Correo.Split('@');
                string dominio = cuerdas[1];

                if (dominio.Contains("gmail.com") || dominio.Contains("hotmail.com") || dominio.Contains("yahoo.com"))
                {
                    _CorreoValido = true;
                    return true;
                }
                else
                {
                    _CorreoValido = false;
                    return false;
                }
            }
            catch
            {
                _CorreoValido = false;
                return false;
            }
        }
        public bool EsValidaContrasegna(string Contrasegna)
        {
            if (Contrasegna.Length < 6)
            {
                _ContrasegnaValido = true;
                return false;
            }
            else
            {
                _ContrasegnaValido = false;
                return true;
            }
        }
        public bool CoincideContrasegna(string Contrasegna1, string Contrasegna2)
        {
            if (Contrasegna1 == Contrasegna2)
            {
                _ContrasegnaCoincide = true;
                return true;
            }
            else
            {
                _ContrasegnaCoincide = false;
                return false;
            }
        }

        public bool TodoEsValido()
        {
            if (_NombreValido && _ApellidoValido && _CorreoValido && _ContrasegnaValido && _ContrasegnaCoincide)
                return true;
            else
                return false;
        }
    }
}
