using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentNamespace.Web.Code.DataAccess.Interfaces;
//using Ent = ContentNamespace.Web.Code.Entities;
using ContentNamespace.Web.Code.Entities;
using Dbml = ContentNamespace.Web.Code.DataAccess.Sql.Dbml;
using ContentNamespace.Web.Code.Util; 


namespace ContentNamespace.Web.Code.DataAccess.Sql
{
    public class SqlApplicationRepository : IApplicationRepository
    {

        Dbml.DataClassesDataContext _db;

        public SqlApplicationRepository(Dbml.DataClassesDataContext dataContext)
        {
            _db = dataContext;
        }

        #region IRepository<Application> Members

        public IQueryable<Application> Get()
        {
            throw new NotImplementedException();
        }

        public ContentNamespace.Web.Code.Entities.Application Save(ContentNamespace.Web.Code.Entities.Application entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ContentNamespace.Web.Code.Entities.Application entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
