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
    public class UserHelper
    {
        Result res;

        public Result Create(User obj)
        {
            try
            {
                using (var db = new OrderContext())
                {
                  var user =  db.Users.Add(
                        new User{
                            Ext_Id = StringExtension.RandomString(20),
                            Name = obj.Name,
                            UserName = obj.UserName,
                            Password = StringExtension.Encrypting(obj.Password),
                            Email = obj.Email,
                            Active = obj.Active,
                            ChangePassword = obj.ChangePassword,
                            UserCreated = 1,
                            Created = DateTime.Now,
                            Updated = DateTime.Now,
                            UserUpdated = 1
                        });
                    db.SaveChanges();
                }
                return new Result { type = ResultType.SUCCESS };

            }
            catch (Exception e)
            {
                return new Result { type = ResultType.FAILED, message = e.Message };
            }
        }
    }
}
