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
        public bool AgregarCustomer(ICliente NuevoCliente)
        {
            return DBManagement.AddCustomer(NuevoCliente.Nombre,
                    NuevoCliente.Apellido, NuevoCliente.Correo,
                    NuevoCliente.Contrasegna);
        }       
        public bool Login(string Correo, string Contrasegna)
        {
            return DBManagement.Login(Correo, Contrasegna);
        }
        public string[] ClienteActivo(ICliente Cliente)
        {
            try
            {
                string[] elCliente = new string[4];
                CUSTOMER c = new CUSTOMER();
                c = DBManagement.getActiveCustomer(Cliente.Correo);
                elCliente[0] = c.FirstName;
                elCliente[1] = c.LastName;
                elCliente[3] = c.Password;
                return elCliente;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }


        }
        public bool ActualizarCustomer(ICliente Cliente)
        {
            return DBManagement.updateCustomer(Cliente.Nombre, Cliente.Apellido, Cliente.Correo, Cliente.Contrasegna);
        }
        public bool AgregarMembership(ICliente Cliente)
        {
            //Este metodo deberia requerir un Cliente a quien agregarle la Membresia 
            return DBManagement.AddMembership();
        }
        public bool AgregarAppPurchased(string NombreApp, ICliente Cliente)
        {
            return DBManagement.AddApp_Purchased(NombreApp, Cliente.Correo);
        }

        //public bool AgregarApp(string _devEmail, string _name, string _description, string _category, byte[] _photo)
        //{
        //    DEVELOPER dev = new DEVELOPER();
        //    //dev.Email=.First(a => a.Name == _name);
        //    return DBManagement.AddApp(dev, _name, _description, _category, _photo);
        //}
        //public bool AgregarComment(CUSTOMER customer, APP app, string _content)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
