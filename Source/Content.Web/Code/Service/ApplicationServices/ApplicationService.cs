using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentNamespace.Web.Code.Entities;
using ContentNamespace.Web.Code.DataAccess.Interfaces;

namespace ContentNamespace.Web.Code.Service.ApplicationServices
{
    public class ApplicationService : IApplicationService
    {
        private IApplicationRepository _repository;

        public ApplicationService(IApplicationRepository repository) 
        {
            this._repository = repository;
        } 

        #region IApplicationService Members

        public IQueryable<Application> Get()
        {
            return  this._repository.Get()  as IQueryable<Application>;
        }

        public Application Get(int id)
        { 
            return this._repository.Get().Where(x => x.Id == id).FirstOrDefault();//.Select(x => new HtmlContent 
        }

        public Application Save(Application item)
        {
            item.ModifiedDate = DateTime.Now; 
            return this._repository.Save(item);
        }

        public bool Delete(Application item)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
