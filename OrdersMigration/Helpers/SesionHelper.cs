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
        public Result Login(User obj)
        {
            try
            {
                User user;
                using (var db = new OrderContext())
                {
                    user = db.Users.Where(u => u.Password == StringExtension.Encrypting(obj.Password) && u.UserName == obj.UserName).FirstOrDefault();
                }

                if (user != null)
                {
                    string sesionString = StringExtension.RandomString(20);
                    user.Sesion = sesionString;
                    using (var db = new OrderContext())
                    {
                        db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                        Sesion.UserName = user.UserName;
                        Sesion.UserId = user.Id;
                        Sesion.SesionString = sesionString;
                        return new Result { type = ResultType.SUCCESS };

                }
                else
                {
                    return new Result { type = ResultType.USER_FAIL };
                }

            }
            catch(Exception e){
                return new Result { type = ResultType.FAILED, message = e.Message };
            }
        }

    }
}
