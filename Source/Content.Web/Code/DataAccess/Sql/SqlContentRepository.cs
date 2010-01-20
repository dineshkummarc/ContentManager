using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentNamespace.Web.Code.DataAccess.Interfaces;
using Ent = ContentNamespace.Web.Code.Entities;
using Sql = ContentNamespace.Web.Code.DataAccess.Sql;

namespace ContentNamespace.Web.Code.DataAccess.Sql
{
    public class SqlContentRepository : SqlBaseRepository, IContentRepository
    {

        Sql.DataClassesDataContext _db;

        public SqlContentRepository(Sql.DataClassesDataContext dataContext)
        {
            _db = dataContext;
        }
         

        #region IRepository<HtmlContent> Members

        public IQueryable<Ent.HtmlContent> Get()
        {
            var r = this._db.HtmlContents.Select(x => new Ent.HtmlContent
            {
                Id = x.Id,
                Name = x.Name,
                ContentData = x.ContentData,
                ActiveDate = x.ActiveDate ?? DateTime.MinValue,
                ExpireDate = x.ExpireDate ??  DateTime.MinValue,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate?? DateTime.MinValue 
                //ContentData = (x.ContentData.Length > _settings.ContentExtractLength) ?
                //               x.ContentData.Substring(0, _settings.ContentExtractLength) + "..." :
                //               x.ContentData,
                //ContentData = x.ContentData,
            }).AsQueryable();
            return r;
        }

        public Ent.HtmlContent Save(Ent.HtmlContent entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Ent.HtmlContent entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
