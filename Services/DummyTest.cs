﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using Datos;

namespace Services
{
    public class DummyTest
    {
        public static string RegresarNombre(string Correo)
        {
            if (Correo == "ge.drms@gmail.com")
                return "Jorge Lopez";
            else
                return null;
        }
        public static bool Existe(string Correo, string Contrasegna)
        {
            if (Correo == "ge.drms@gmail.com" && Contrasegna == "asdasd")
                return true;
            else
                return false;
        }

       // public static bool Registrar(string Nombre, string Apellido, string Correo, string Contrasegna)
         public static void Registrar(string Nombre, string Apellido, string Correo, string Contrasegna)
        {
            //if (Existe(Correo, Contrasegna))
            //{
                DBManagement.AddCustomer(Nombre, Apellido, Correo, Contrasegna);
                //return true;
                //procede con SQL connection String
            //}
            //else
            //{
            //    throw new InvalidOperationException("Ya existe un usuario con el mismo correo");
            //}
        }

        /*
        public string Regresar(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }/*/
    }
}