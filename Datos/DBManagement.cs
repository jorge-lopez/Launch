using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DBManagement
    {
        #region Add Methods
        //Metodo que agrega un Customer a la base de datos
        public static bool AddCustomer(string _FirstName, string _LastName, string _Email, string _Password)
        {
            using (var dbContext = new LAUNCHEntities())
            {
                //verifica si ya existe un customer en la base de datos con ese email
                var Existent = (from c in dbContext.CUSTOMERs
                              where c.Email == _Email
                              select c).Any();
                //tira una excepcion si ya existe, y si no, agrega al customer a la base y lo guarda
                if (Existent == true)
                {
                    throw new InvalidOperationException("Ya existe un usuario con ese correo. Escoge otro");
                }
                else
                {
                    var customer = new CUSTOMER
                    {
                        FirstName = _FirstName,
                        LastName = _LastName,
                        Email = _Email,
                        Password = _Password
                    };
                    dbContext.CUSTOMERs.Add(customer);
                    var changesSaved = dbContext.SaveChanges();
                    return changesSaved >= 1;
                }
            }
        }

        //Metodo que agrega un Developer a la base de datos
        public static bool AddDeveloper(string _FirstName, string _LastName, string _Email, string _Password)
        {
            using (var dbContext = new LAUNCHEntities())
            {
                var Existent = (from c in dbContext.DEVELOPERs
                                where c.Email == _Email
                                select c).Any();
                //tira una excepcion si ya existe, y si no, agrega al developer a la base y lo guarda
                if (Existent == true)
                {
                    throw new InvalidOperationException("Ya existe un developer con ese correo. Escoge otro");
                }
                else
                {
                    var developer = new DEVELOPER
                    {
                        FirstName = _FirstName,
                        LastName = _LastName,
                        Email = _Email,
                        Password = _Password
                    };
                    dbContext.DEVELOPERs.Add(developer);
                    var changesSaved = dbContext.SaveChanges();
                    return changesSaved >= 1;
                }
            }
        }

        //Metodo que agrega una App a la base de datos
        public static bool AddApp(DEVELOPER user, string _Name, string _Description, string _Category, Byte[] _Photo)
        {
            using (var dbContext = new LAUNCHEntities())
            {
                var Existent = (from c in dbContext.APPs
                                where c.Name == _Name
                                select c).Any();
                if (Existent == true)
                {
                    throw new InvalidOperationException("Ya existe un developer con ese correo. Escoge otro");
                }
                else
                {
                    var app = new APP
                    {
                        ID_Developer = user.ID_Developer,
                        Name = _Name,
                        PublishedDate = DateTime.Now,
                        Description = _Description,
                        Category = _Category,
                        Photo = _Photo,
                        MembershipQueue = false
                    };
                    dbContext.APPs.Add(app);
                    var changesSaved = dbContext.SaveChanges();
                    return changesSaved >= 1;
                }
            }
        }
        //Metodo que agrega comments a una aplicacion
        public static bool AddComment(CUSTOMER customer, APP app, string _content)
        {
            using (var dbContext = new LAUNCHEntities())
            {
                    var comment = new COMMENT
                    {
                        ID_Customer=customer.ID_Customer,
                        ID_App=app.ID_App,
                        Date=DateTime.Now,
                        Content=_content
                    };
                    dbContext.COMMENTs.Add(comment);
                    var changesSaved = dbContext.SaveChanges();
                    return changesSaved >= 1;
                }
            }

        public static bool AddMembership()
        {
            using (var dbContext = new LAUNCHEntities())
            {
                var membership=new MEMBERSHIP
                {
                    LastPayment=DateTime.Now,
                    Active=true
                };
                dbContext.MEMBERSHIPs.Add(membership);
                var changesSaved = dbContext.SaveChanges();
                return changesSaved >= 1;
            }

        }

        public static bool AddApp_Purchased(APP app, CUSTOMER customer)
        {
             using (var dbContext = new LAUNCHEntities())
             {
                 var app_purchased = new APP_PURCHASED
                 {
                     ID_App = app.ID_App,
                     ID_Customer = customer.ID_Customer
                 };
                 dbContext.APP_PURCHASED.Add(app_purchased);
                 var changesSaved = dbContext.SaveChanges();
                 return changesSaved >= 1;

             }

        }

        #endregion

        #region Read Methods

        #endregion

    }
}
