using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using Datos;
using Commons;

namespace Services
{
    //Dummy para Login!
    public class Service : IService
    {        
        public bool AgregarCustomer(string Nombre, string Apellido, string Correo, string Contrasegna)
        {
            return DBManagement.AddCustomer(Nombre, Apellido, Correo, Contrasegna);
        }       
        /// <summary>
        /// Regresa dos bools, siendo el primero si precedio o no el login
        /// El segundo nso indica si es un Cliente, de ser falso seria un Developer
        /// </summary>
        /// <param name="Correo"></param>
        /// <param name="Contrasegna"></param>
        /// <returns>bool[0] = Procedio, bool[1]= IsCliente</returns>
        public bool[] Login(string Correo, string Contrasegna)
        {
            return DBManagement.Login(Correo, Contrasegna);
        }
        public string[] ClienteActivo(string Correo)
        {
            try
            {
                var c = DBManagement.getActiveCustomer(Correo);
                string[] valores = new string[3];
                valores[0] = c.FirstName;
                valores[1] = c.LastName;
                valores[2] = c.Password;
                return valores;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public bool ActualizarCustomer(string Nombre, string Apellido, string Correo, string Contrasegna)
        {
            return DBManagement.updateCustomer(Nombre, Apellido, Correo, Contrasegna);
        }
        public bool AgregarMembership(string Correo)
        {
            //Este metodo deberia requerir un Cliente a quien agregarle la Membresia 
            return DBManagement.AddMembership();
        }
        public bool AgregarAppPurchased(string NombreApp, string Correo)
        {
            return DBManagement.AddApp_Purchased(NombreApp, Correo);
        }
        

        public bool AgregarDeveloper(string Nombre, string Apellido, string Correo, string Contrasegna)
        {
            return DBManagement.AddDeveloper(Nombre, Apellido, Correo, Contrasegna);
        }

        public bool ActualizarDeveloper(string Nombre, string Apellido, string Correo, string Contrasegna)
        {
            return DBManagement.updateDeveloper(Nombre, Apellido, Correo, Contrasegna);
        }
        public string[] DesarrolladorActivo(string Correo)
        {
            try
            {
                var c = DBManagement.getActiveDeveloper(Correo);
                string[] valores = new string[3];
                valores[0] = c.FirstName;
                valores[1] = c.LastName;
                valores[2] = c.Password;
                return valores;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
        public bool AgregarApp(string _devEmail, string _name, string _description, string _category, byte[] _photo)
        {
            return DBManagement.AddApp(_devEmail, _name, _description, _category, _photo);
        }
        public List<List<string>> ObtenerAppsDeveloper(string Correo)
        {
            return DBManagement.getAppsPublishedByDeveloper(Correo);
        }
        public byte[] ObtenerImagenApp(string Correo)
        {
            return DBManagement.getAppsPhoto(Correo);
        }
        public List<List<string>> ObtenerAppsSuscripcion() 
        {
            return DBManagement.getSuscriptionApps();
        }
        public List<List<string>> ObtenerAppsRecientes()
        {
            return DBManagement.getRecentApps();
        }
        //public bool AgregarComment(CUSTOMER customer, APP app, string _content)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
