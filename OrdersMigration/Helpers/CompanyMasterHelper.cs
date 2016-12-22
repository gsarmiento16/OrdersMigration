using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrdersMigration.Database;
using OrdersMigration.Models;
using OrdersMigration.Util;
using OrdersMigration.ViewModels;

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
                            Updated = DateTime.Now,
                            UserUpdated = Sesion.UserId 
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

        public ICollection<CompanyMasterViewModel> List()
        {
            using (var db = new OrderContext())
            {
             var list = from cm in db.CompanieMasters
                        join uc in db.Users on cm.UserCreated equals uc.Id  
                        join uu in db.Users on cm.UserUpdated equals uu.Id  
                        select new CompanyMasterViewModel {
                              Ext_Id = cm.Ext_Id,
                              Name = cm.Name,
                              Code = cm.Code,
                              Updated = cm.Updated,
                              Created = cm.Created,
                              UserCreated = uc.UserName,
                              UserUpdated = uu.UserName
                          };
             return list.ToList();
            }
        }

    }
}
