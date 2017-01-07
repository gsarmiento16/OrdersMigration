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
                            UserCreated = Sesion.UserId,
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

        public Result Update(string Ext_Id)
        {
            Result res = new Result();
            CompanyMaster companyMaster = new CompanyMaster();
            try
            {
                using (var db = new OrderContext())
                {
                    companyMaster = db.CompanieMasters.Where(c => c.Ext_Id.Equals(Ext_Id)).FirstOrDefault();
                }

                if (companyMaster != null)
                {
                    using (var db = new OrderContext())
                    {
                        db.Entry(companyMaster).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                }

                return new Result { type = ResultType.SUCCESS };
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

        public CompanyMaster Get(string Ext_Id)
        {
            using (var db = new OrderContext())
            {
                var item = (from cm in db.CompanieMasters
                            select cm).FirstOrDefault();
                return item;
            }
        }

        public Result Delete(List<string> Ids)
        {
            try
            {
                using (var db = new OrderContext())
                {
                    List<CompanyMaster> list = new List<CompanyMaster>();

                    foreach (var item in Ids)
                    {
                        var cm = (from m in db.CompanieMasters
                                  where m.Ext_Id.Equals(item)
                                  select m).FirstOrDefault();
                        if (cm != null)
                        {
                            list.Add(cm);
                        }

                    }

                    if (list.Count()>0)
                    {
                        db.CompanieMasters.RemoveRange(list);
                        db.SaveChanges();
                    }
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
