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
                    try
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
                    catch(Exception ex)
                    {
                        string error = ex.Message;
                        return false;
                    }
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
                    throw new InvalidOperationException("Ya existe un App con ese nombre. Escoge otro");
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
                    ID_Customer = customer.ID_Customer,
                    ID_App = app.ID_App,
                    Date = DateTime.Now,
                    Content = _content
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
                var membership = new MEMBERSHIP
                {
                    LastPayment = DateTime.Now,
                    Active = true
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
        //Manda llamar de la base de datos el Customer con el email que se le mande
        public static CUSTOMER getActiveCustomer(string _email)
        {
            using (var dbContext = new LAUNCHEntities())
            {
                return dbContext.CUSTOMERs.First(u => u.Email == _email);
            }
        }

        //Manda llamar de la base de datos el Developer con el email que se le mande
        public static DEVELOPER getActiveDeveloper(string _email)
        {
            using (var dbContext = new LAUNCHEntities())
            {
                return dbContext.DEVELOPERs.First(d => d.Email == _email);
            }
        }

        //Lee todas las aplicaciones disponibles en la base de datos
        public static List<APP> getAllApps()
        {
            using (var dbContext = new LAUNCHEntities())
            {
                List<APP> theApps = new List<APP>();
                var getApps = from a in dbContext.APPs
                              select a;

                foreach (var g in getApps)
                {
                    theApps.Add(g);
                }
                return theApps;
            }

        }
        //Da la informacion de la App solicitada
        public static APP getInfofromApp(string _name)
        {
            using (var dbContext= new LAUNCHEntities())
            {
                return dbContext.APPs.First(a => a.Name == _name);
            }

        }

        //Lee todos los comments disponibles de una aplicacion
        public static List<COMMENT> getAllCommentsFromApp(APP app)
        {
            using (var dbContext = new LAUNCHEntities())
            {
                List<COMMENT> theComments = new List<COMMENT>();
                var getComments = from c in dbContext.COMMENTs
                                  where c.ID_App == app.ID_App
                                  select c;

                foreach (var c in getComments)
                {
                    theComments.Add(c);
                }
                return theComments;

            }

        }

        //Lee todas las aplicaciones compradas por un usuario
        public static List<APP_PURCHASED> getAppsPurchasedByCustomer(CUSTOMER customer)
        {
            using (var dbContext = new LAUNCHEntities())
            {
                List<APP_PURCHASED> thePurchases = new List<APP_PURCHASED>();
                var getPurchases = from p in dbContext.APP_PURCHASED
                                   where p.ID_Customer == customer.ID_Customer
                                   select p;

                foreach (var p in getPurchases)
                {
                    thePurchases.Add(p);
                }
                return thePurchases;
            }

        }
        #endregion


        #region Update Methods
        public static bool updateCustomer(string _firstName, string _lastName, string _email, string _password)
        {
            using (var dbContext= new LAUNCHEntities())
            {
                var buscarCustomer = from c in dbContext.CUSTOMERs
                                     where c.Email == _email
                                     select c;
                foreach (var c in buscarCustomer)
                {
                    c.FirstName = _firstName;
                    c.LastName = _lastName;
                    c.Email = _email;
                    c.Password = _password;
                }
                var changesSaved = dbContext.SaveChanges();
                return changesSaved >= 1;
            }
        }



        #endregion


    }
}
