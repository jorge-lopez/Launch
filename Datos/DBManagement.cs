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
                var Existe = (from c in dbContext.CUSTOMERs
                              where c.Email == _Email
                              select c).Any();

                //tira una excepcion si ya existe, y si no, agrega al customer a la base y lo guarda
                if (Existe == true)
                {
                    throw new InvalidOperationException("Ya existe un usuario con ese correo. Escoje otro");
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

        //Metodo que agrega una App a la base de datos
        public static bool AddApp(DEVELOPER user,string _Name, string _Description, string _Category, Byte[] _Photo)
        {
            using (var dbContext= new LAUNCHEntities())
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


        #endregion
    }
}
