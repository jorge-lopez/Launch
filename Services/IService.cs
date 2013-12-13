using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Datos;

namespace Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        #region Agregar Entidades
        [OperationContract]
        bool AgregarCustomer(string _FirstName, string _LastName, string _email, string _password);
        [OperationContract]
        bool AgregarDeveloper(string _FirstName, string _LastName, string _email, string _password);
        [OperationContract]
        bool AgregarApp(DEVELOPER developer, string _name, string _description, string _category, Byte[] _photo);
        [OperationContract]
        bool AgregarComment(CUSTOMER customer, APP app, string _content);
        [OperationContract]
        bool AgregarMembership();
        [OperationContract]
        bool AgregarAppPurchased(APP app, CUSTOMER customer);

        #endregion

#region Leer todas las entidades
        [OperationContract]
        List<APP> ObtenerApps();

        [OperationContract]
        List<CUSTOMER> ObtenerCustomers();

        [OperationContract]
        List<DEVELOPER> ObtenerDevelopers();

        [OperationContract]
        List<COMMENT> ObtenerComments();

        [OperationContract]
        List<MEMBERSHIP> ObtenerMemberships();

        [OperationContract]
        List<APP_PURCHASED> ObtenerAppsPurchased();

#endregion

#region Leer personalizados
        [OperationContract]
        CUSTOMER obtenerCustomerActivo(string _email);

        [OperationContract]
        DEVELOPER obtenerDeveloperActivo(string _email);

        [OperationContract]
        APP obtenerApp(string _name);

        [OperationContract]
        List<APP_PURCHASED> obtenerAppsCompradasPorCliente(CUSTOMER customer);


        




#endregion

        #region Hacer updates
        [OperationContract]
        bool actualizarCustomer(string _firstName, string _lastName, string _email, string _password);
        #endregion

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
