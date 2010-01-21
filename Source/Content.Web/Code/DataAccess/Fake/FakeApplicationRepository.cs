using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentNamespace.Web.Code.DataAccess.Interfaces;
using ContentNamespace.Web.Code.Entities;

namespace ContentNamespace.Web.Code.DataAccess.Fake
{
    public class FakeApplicationRepository : IApplicationRepository
    {

        IList<Application> list = new List<Application>();

        public FakeApplicationRepository()
        { 
            int i = 0;
            while ( i < 2)
            {
                Application x = new Application();
                i++;
                x.Name = "AppName" + i;
                x.Id = i;
                x.CreatedDate = new DateTime(2000, 1, 1);
                x.ModifiedDate = new DateTime(2000, 1, 1);
                x.CreatedBy = "xx";
                x.ModifiedBy = "xx";
                list.Add(x);
            }  
        }

        #region IRepository<Application> Members

        public IQueryable<ContentNamespace.Web.Code.Entities.Application> Get()
        {
            return list.AsQueryable<Application>();
        }

        public Application Save(Application item)
        {
            if (item.Id > 0)
            {
                Application w = this.list.Where(x => x.Id == item.Id).SingleOrDefault();
                if (w != null)
                {
                    w = item;
                }
                else
                {
                    list.Add(item);
                }
            }
            else
            {
                int maxId = this.list.Max(x => x.Id);
                item.Id = maxId + 1;
                this.list.Add(item);
            }
            return item;
        }

        public bool Delete(ContentNamespace.Web.Code.Entities.Application entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
