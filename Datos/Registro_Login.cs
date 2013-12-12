using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Registro_Login
    {
        //Metodo que agrega un Costumer a la base de datos
        public static bool AddCostumer(string _FirstName, string _LastName, string _Email, string _Password)
        {
            using (var dbContext= new LAUNCHEntities())
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


    }
}
