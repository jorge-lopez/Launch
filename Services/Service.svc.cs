using System;
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
    //Dummy para Login!
    public class Service
    {


        static public bool AgregarCustomer(string _FirstName, string _LastName, string _email, string _password)
        {
            return DBManagement.AddCustomer(_FirstName, _LastName, _email, _password);
        }

        public bool AgregarDeveloper(string _FirstName, string _LastName, string _email, string _password)
        {
            return DBManagement.AddDeveloper(_FirstName, _LastName, _email, _password);
        }

        public bool AgregarApp(string _devEmail, string _name, string _description, string _category, byte[] _photo)
        {
            DEVELOPER dev = new DEVELOPER();
            //dev.Email=.First(a => a.Name == _name);
            return DBManagement.AddApp(dev, _name, _description, _category, _photo);
        }

        public bool AgregarComment(CUSTOMER customer, APP app, string _content)
        {
            throw new NotImplementedException();
        }

        public bool AgregarMembership()
        {
            throw new NotImplementedException();
        }

        public bool AgregarAppPurchased(APP app, CUSTOMER customer)
        {
            throw new NotImplementedException();
        }

        public List<APP> ObtenerApps()
        {
            throw new NotImplementedException();
        }

        public List<CUSTOMER> ObtenerCustomers()
        {
            throw new NotImplementedException();
        }

        public List<DEVELOPER> ObtenerDevelopers()
        {
            throw new NotImplementedException();
        }

        public List<COMMENT> ObtenerComments()
        {
            throw new NotImplementedException();
        }

        public List<MEMBERSHIP> ObtenerMemberships()
        {
            throw new NotImplementedException();
        }

        public List<APP_PURCHASED> ObtenerAppsPurchased()
        {
            throw new NotImplementedException();
        }

        public CUSTOMER obtenerCustomerActivo(string _email)
        {
            throw new NotImplementedException();
        }

        public DEVELOPER obtenerDeveloperActivo(string _email)
        {
            throw new NotImplementedException();
        }

        public APP obtenerApp(string _name)
        {
            throw new NotImplementedException();
        }

        public List<APP_PURCHASED> obtenerAppsCompradasPorCliente(CUSTOMER customer)
        {
            throw new NotImplementedException();
        }

        public bool actualizarCustomer(string _firstName, string _lastName, string _email, string _password)
        {
            throw new NotImplementedException();
        }

        public string GetData(int value)
        {
            throw new NotImplementedException();
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            throw new NotImplementedException();
        }





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

        public static bool Registrar(IUsuario Cliente)
        {
            if (Existe(Cliente.Correo, Cliente.Contrasegna))
            {
                return true;
                //procede con SQL connection String
            }
            else
            {
                throw new InvalidOperationException("Ya existe un usuario con el mismo correo");
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
}
