using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrdersMigration.Database;
using OrdersMigration.Models;
using OrdersMigration.Util;

namespace OrdersMigration.Helpers
{
    public class CompanyMasterHelper
    {
      public Result Create(CompanyMaster obj)
        {
            Result res = new Result();
            try
            {
                using (var db = new OrderContext())
                {
                    db.CompanieMasters.Add(
                        new CompanyMaster {
                            Ext_Id = StringExtension.RandomString(20),
                            Name = obj.Name,
                            Code = obj.Code,
                            UserCreated = 15548,
                            Created = DateTime.Now,
                            Updated= DateTime.Now,
                            UserUpdated = 15548
                        });
                    db.SaveChanges();
                    return new Result { type = ResultType.SUCCESS };

                }
            }
            catch (Exception e)
            {
                return new Result { type = ResultType.FAILED, message = e.Message };
            }
        }

    }
}
