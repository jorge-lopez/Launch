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
        //Metodo que agrega un Costumer a la base de datos
        public static bool AddCostumer(string _FirstName, string _LastName, string _Email, string _Password)
        {
            using (var dbContext = new LAUNCHEntities())
            {
                var Existe = (from c in dbContext.COSTUMERs
                              where c.Email == _Email
                              select c).Any();

                if (Existe == true)
                {
                    throw new InvalidOperationException("Ya existe un usuario con ese correo. Escoje otro");
                }

                else
                {
                    var costumer = new COSTUMER
                    {
                        FirstName = _FirstName,
                        LastName = _LastName,
                        Email = _Email,
                        Password = _Password
                    };
                    dbContext.COSTUMERs.Add(costumer);

                    var changesSaved = dbContext.SaveChanges();

                    return changesSaved >= 1;
                }
            }
        }

        //Metodo que agrega un Costumer a la base de datos
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

        //Metodo que agrega un Costumer a la base de datos
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
