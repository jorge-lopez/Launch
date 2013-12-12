using BuisenessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Launch
{
    class ModeloRegistro : IDataErrorInfo
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Contrasegna { get; set; }
        public string Verifica { get; set; }

        public ModeloRegistro() { }
        public ModeloRegistro(string correo)
        {
            Cliente c = new Cliente(correo);
            Nombre = c.Nombre;
            Apellido = c.Apellido;
            Correo = c.Correo;
            Contrasegna = c.Contrasegna;
            Verifica = Contrasegna;
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
                if (columnName == "Apellido")
                {
                    if (string.IsNullOrEmpty(Apellido))
                        result = "Introdusca un " + columnName;
                }
                if (columnName == "Correo")
                {
                    if (string.IsNullOrEmpty(Correo))
                        result = "Introdusca un " + columnName;
                    else if (Correo.Length < 13)
                        result = "Introdusca correo valido";
                    else if((Correo.EndsWith("@gmail.com") == false) &&
                            (Correo.EndsWith("@yahoo.com") == false) &&
                            (Correo.EndsWith("@hotmail.com") == false))
                        result = "Introdusca correo valido";
                }
                if (columnName == "Contrasegna")
                {
                    if (string.IsNullOrEmpty(Contrasegna))
                        result = "Introdusca un " + columnName;
                    else if (Contrasegna.Length < 6)
                        result = "Introdusca una contraseña mas grande";
                }

                if (columnName == "Verifica")
                {
                    if (string.IsNullOrEmpty(Contrasegna))
                        result = "Introdusca un " + columnName;
                    else if (Verifica != Contrasegna)
                        result = "Contrasegna Incorrecta";
                }
                

                return result;
            }
        }
    }

    

}
