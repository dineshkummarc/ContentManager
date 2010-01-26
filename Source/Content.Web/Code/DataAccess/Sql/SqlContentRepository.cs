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
                ActiveDate = x.ActiveDate ?? new DateTime(1753, 1,1),
                ExpireDate = x.ExpireDate ?? new DateTime(1753, 1, 1),
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate ?? new DateTime(1753, 1, 1),
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate ?? new DateTime(1753, 1, 1)  
            }).AsQueryable();
            return r;
        }

        public Ent.HtmlContent Save(Ent.HtmlContent item)
        {
            using (DataClassesDataContext db = new DataClassesDataContext(this.ConnStr))
            {
                HtmlContent dbItem = db.HtmlContents.Where(x => x.Id == item.Id).SingleOrDefault();
                bool isNew = false;
                if (dbItem == null)
                {
                    dbItem = new HtmlContent();
                    isNew = true;
                }
                //else
                //{
                //    //remove them for refresh
                //    //wish there was a better way to do this but... 
                //    //db.TalentEvents.DeleteAllOnSubmit(db.TalentEvents.Where(x => x.TalentID == t.Id));
                //    //db.TalentLanguages.DeleteAllOnSubmit(db.TalentLanguages.Where(x => x.TalentID == t.Id));
                //    //db.TalentTypeTalents.DeleteAllOnSubmit(db.TalentTypeTalents.Where(x => x.TalentID == t.Id));

                //    //db.TalentFiles.DeleteAllOnSubmit(db.TalentFiles.Where(x => x.TalentID == t.Id));
                //    //db.TalentStates.DeleteAllOnSubmit(db.TalentStates.Where(x => x.TalentID == t.Id)); 
                //}
                //foreach (Model.Model.TalentEvent tdb in t.TalentEvents)
                //{
                //    SqlServer.TalentEvent dbTe = new SqlServer.TalentEvent();
                //    dbTe.TalentID = t.Id;
                //    dbTe.EventID = tdb.EventID;
                //    dbT.TalentEvents.Add(dbTe);
                //} 
                dbItem.Name = item.Name;
                dbItem.ContentData = item.ContentData;
                dbItem.ActiveDate = item.ActiveDate;
                dbItem.ExpireDate = item.ExpireDate ;
                dbItem.ModifiedBy  = item.ModifiedBy;
                dbItem.ModifiedDate = item.ModifiedDate;


                if (isNew)
                {
                    db.HtmlContents.InsertOnSubmit(dbItem);
                }
                try
                {
                    db.SubmitChanges();
                }
                catch (Exception e)
                {
                    string s = e.Message;
                    throw;
                }
                item.Id = dbItem.Id;
                return item;
            }

        } 
        public bool Delete(Ent.HtmlContent entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
