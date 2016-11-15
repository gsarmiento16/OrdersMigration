using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrdersMigration.Models;
using OrdersMigration.Database;
using OrdersMigration.Util;
namespace OrdersMigration.Helpers
{
    public class SesionHelper
    {
        public int Login(User obj)
        {
            try
            {
                using (var db = new OrderContext())
                {
                    var user = db.Users.Where(u => u.Password == StringExtension.Encrypting(obj.Password) && u.UserName == obj.UserName).FirstOrDefault();

                    if (user != null)
                    {
                        Sesion.UserName = user.UserName;
                        Sesion.UserId = user.Id;
                        Sesion.SesionString = user.Sesion;
                    }
                    else { }
                }
            }catch(Exception e){


            }
            return 0;
        }

    }
}
