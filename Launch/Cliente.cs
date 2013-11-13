using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launch
{
    class Cliente : Usuario
    {
        //List<Aplicaciones> appsInstaladas = new List<Aplicaciones>();

        public Cliente(string Nombre, string Correo)
        {
            this.Nombre = Nombre;
            this.Correo = Correo;
        }

        public void Instalar()
        { }
        public void ComprarMembresia()
        { }
        public void Buscar()
        { }
        public void Remover()
        { }
    }
}
