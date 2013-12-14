using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Datos;
using Commons;

namespace Services
{
    //Se han comentado aquellos metodos, en los cuales el alcance aun no ha sido considerado

    [ServiceContract]
    public interface IService
    {

        [OperationContract]
        bool AgregarCustomer(ICliente NuevoCliente);                
        [OperationContract]
        bool Login(string Correo, string Contrasegna);
        [OperationContract]
        string[] ClienteActivo(ICliente Cliente);
        [OperationContract]
        bool ActualizarCustomer(ICliente Cliente);
        [OperationContract]
        bool AgregarMembership(ICliente Cliente);
        [OperationContract]
        bool AgregarAppPurchased(string NombreApp, ICliente customer);
        
        //Metodos Por usarse
        //[OperationContract]
        //bool AgregarDeveloper(string _FirstName, string _LastName, string _email, string _password);
        //[OperationContract]
        //bool AgregarApp(DEVELOPER developer, string _name, string _description, string _category, Byte[] _photo);
        //[OperationContract]
        //bool AgregarComment(CUSTOMER customer, APP app, string _content);

        //[OperationContract]
        //List<APP> ObtenerApps();

        //[OperationContract]
        //List<DEVELOPER> ObtenerDevelopers();

        //[OperationContract]
        //List<COMMENT> ObtenerComments();

        //[OperationContract]
        //List<APP_PURCHASED> ObtenerAppsPurchased(ICliente ClienteActivo);

        //[OperationContract]
        //CUSTOMER obtenerCustomerActivo(string Correo);

        //[OperationContract]
        //DEVELOPER obtenerDeveloperActivo(string Correo);

        //[OperationContract]
        //APP obtenerApp(string AppNombre);

        //[OperationContract]
        //List<APP_PURCHASED> obtenerAppsCompradasPorCliente(CUSTOMER customer);

    }
}
