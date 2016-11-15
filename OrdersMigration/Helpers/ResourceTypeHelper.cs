using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrdersMigration.Models;
using OrdersMigration.Util;
using OrdersMigration.Database;
namespace OrdersMigration.Helpers
{
   public  class ResourceTypeHelper
    {
        private Result<ResourceType> res;

        public Result<ResourceType> Create(ResourceType obj)
        {
            res = new Result<ResourceType>();
            ResourceType resourceType = new ResourceType();
            try
            {
                using (var db = new OrderContext())
                {
                    resourceType = new ResourceType
                    {
                        Name = obj.Name,
                        Ext_id = StringExtension.RandomString(20),
                        Code = obj.Code
                    };
                    db.ResourceTypes.Add(resourceType);
                    db.SaveChanges();
                }
                res.type = 1;
                res.Entity = resourceType.Id;
                return res;
            }
            catch(Exception e)
            {
                res.type = 0;
                res.message = e.Message;
                return res;
            }
        }

        public ResourceType Get(long id)
        {
            ResourceType resourceType;
            using (var db = new OrderContext())
            {
                resourceType = db.ResourceTypes.Where(rt => rt.Id == id).FirstOrDefault();
            }
            if (resourceType != null)
            {

            }
                return resourceType;
        }

        public ICollection<ResourceType> ListAll()
        {
            ICollection<ResourceType> list;
            using (var db = new OrderContext())
            {
                list = db.ResourceTypes.ToList();
            }
            return list;
        }

        public Result<ResourceType> update(ResourceType obj)
        {
            res = new Result<ResourceType>();
            ResourceType resourceType;
            using (var db = new OrderContext())
            {
                resourceType = db.ResourceTypes.Where(rt => rt.Id == obj.Id).FirstOrDefault();
            }

            if (resourceType != null)
            {
                resourceType.Name = obj.Name;
                resourceType.Active = obj.Active;

                using (var db = new OrderContext())
                {
                    db.Entry(resourceType).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return res;
        }

        public Result<ResourceType> Delete(long id)
        {
            try
            {
                res = new Result<ResourceType>();
                using (var db = new OrderContext())
                {
                    ResourceType resourceType;
                    resourceType = db.ResourceTypes.Where(rt => rt.Id == id).FirstOrDefault();

                    if (resourceType != null)
                    {
                        db.Entry(resourceType).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        res.type = ResultType.SUCCESS;
                    }
                    else
                    {
                        res.type = ResultType.FAILED;
                    }

                }
                return res;
            }
            catch (Exception e)
            {
                res.type = ResultType.FAILED;
                return res;
            }
        }

    }
}
