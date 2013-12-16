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
        bool AgregarCustomer(string Nombre, string Apellido, string Correo, string Contrasegna);                
        [OperationContract]
        bool[] Login(string Correo, string Contrasegna);
        [OperationContract]
        string[] ClienteActivo(string Correo);
        [OperationContract]
        bool ActualizarCustomer(string Nombre, string Apellido, string Correo, string Contrasegna);
        [OperationContract]
        bool AgregarMembership(string Correo);
        [OperationContract]
        bool AgregarAppPurchased(string NombreApp, string Correo);
        
        //Metodos Por usarse
        [OperationContract]
        bool AgregarDeveloper(string Nombre, string Apellido, string Correo, string Contrasegna);
        [OperationContract]
        bool ActualizarDeveloper(string Nombre, string Apellido, string Correo, string Contrasegna);
        [OperationContract]
        string[] DesarrolladorActivo(string Correo);
        [OperationContract]
        bool AgregarApp(string CorreoDesarrollador, string Nombre, string Descripcion, string Categoria, byte[] Imagen);
        //[OperationContract]
        //bool AgregarComment(CUSTOMER customer, APP app, string _content);

        [OperationContract]
        List<List<string>> ObtenerAppsDeveloper(string Correo);
        [OperationContract]
        byte[] ObtenerImagenApp(string Correo);

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
        [OperationContract]
        List<List<string>> ObtenerAppsSuscripcion();
        [OperationContract]
        List<List<string>> ObtenerAppsRecientes();
        [OperationContract]
        List<List<string>> ObtenerAppsComprados(string Correo);
        [OperationContract]
        List<string> ObtenerAppInfo(int IdApp);
    }
}
