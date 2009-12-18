using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentNamespace.Web.Code.DataAccess.Interfaces;
using ContentNamespace.Web.Code.Entities;
using Sql = ContentNamespace.Web.Code.DataAccess.Sql;

namespace ContentNamespace.Web.Code.DataAccess.Sql
{
    public class SqlContentRepository : SqlBaseRepository, IContentRepository
    {

        //Sql.DataClassesDataContext _db;

        //public SqlContentRepository(Sql.DataClassesDataContext dataContext)
        //{
        //    _db = dataContext;
        //}


        #region IRepository<HtmlContent> Members

        public IQueryable<HtmlContent> Get()
        {
            /*
            var r = _db.HtmlContents.Select(x => new HtmlContent
            {
                Id = x.Id,
                Name = x.Name,
            });
            return r;*/
            throw new NotImplementedException();
        }

        public HtmlContent Save( HtmlContent entity)
        {
            /*
            using (Sql.DataClassesDataContext db = new Sql.DataClassesDataContext(this.ConnStr))
            {
                Sql.Htmlcontent dbItem =
                    db.Htmlcontents.Where(x => x.Id == entity.Id).SingleOrDefault();
                bool isNew = false;
                if (dbItem == null)
                {
                    dbItem = new Sql.Htmlcontent();
                    isNew = true;
                }

                dbItem.Name = entity.Name; 
                //dbItem.Name2 = entity.Name2; 
                //dbItem.Name3 = entity.Name3; 
                //dbItem.Name4 = entity.Name4; 
                if (isNew)
                {
                    db.Htmlcontents.InsertOnSubmit(dbItem);
                }
                db.SubmitChanges();
                entity.Id = dbItem.Id;
                return entity;
            }*/

            throw new NotImplementedException();
        }

        public bool Delete( HtmlContent entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
