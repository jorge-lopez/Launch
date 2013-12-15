using BuisenessLogic;
using Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launch.ViewModel
{
    class ModeloPublicarApp : IDataErrorInfo
    {        
        public string Nombre { get; set; }        
        public string Categoria{ get; set; }
        public string Descripcion{ get; set; }
        public byte[] Imagen { get; set; }


        public ModeloPublicarApp () { }
        public ModeloPublicarApp(IApp Aplicacion)
        {
            Nombre = Aplicacion.Nombre;
            Categoria = Aplicacion.Categoria;
            Descripcion = Aplicacion.Descripcion;
            Imagen = Aplicacion.Imagen;
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (columnName == "Nombre")
                {
                    if (string.IsNullOrEmpty(Nombre))
                        result = "Introdusca un " + columnName;
                }
                if (columnName == "Categoria")
                {
                    if (string.IsNullOrEmpty(Categoria))
                        result = "Introdusca un " + columnName;
                }
                if (columnName == "Descripcion")
                {
                    if (string.IsNullOrEmpty(Descripcion))
                        result = "Introdusca un " + columnName;
                }                

                return result;
            }
        }
    }
}
