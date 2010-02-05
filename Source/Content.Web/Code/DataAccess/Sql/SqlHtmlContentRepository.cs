using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentNamespace.Web.Code.DataAccess.Interfaces;
using ContentNamespace.Web.Code.Entities;
using Ent = ContentNamespace.Web.Code.Entities;
using Dbml = ContentNamespace.Web.Code.DataAccess.Sql.Dbml;
using ContentNamespace.Web.Code.Util;

namespace ContentNamespace.Web.Code.DataAccess.Sql
{
    public class SqlHtmlContentRepository : SqlBaseRepository, IHtmlContentRepository
    {

        Dbml.DataClassesDataContext _db;

        public SqlHtmlContentRepository(Dbml.DataClassesDataContext dataContext)
        {
            _db = dataContext;
        }

        public PagedList<HtmlContent> Get(int pageIndex, int pageSize, out int totalCount) 
        {
            var query = new PagedList<HtmlContent>(Get(), pageIndex, pageSize);
            totalCount = query.TotalCount;

            return query;
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
                CreatedDate = x.CreatedDate ?? new DateTime(1753, 1, 1),
                ItemState = SqlHtmlContentRepository.GetContentStateEnum((int)x.ItemState)
            }).AsQueryable();
            return r;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        private static Enums.ContentState GetContentStateEnum(int? intValue)
        {
            switch (intValue)
            {
                case 0: { return Enums.ContentState.Created; }
                case 1: { return Enums.ContentState.InProgress; }
                case 2: { return Enums.ContentState.Submitted; }
                case 3: { return Enums.ContentState.Published; }
                case 4: { return Enums.ContentState.Expired; }
                case 99: { return Enums.ContentState.Rejected; }
                default: { return Enums.ContentState.Created; }
            }
        }

        public Ent.HtmlContent Save(Ent.HtmlContent entity)
        {
            using (Dbml.DataClassesDataContext db = new Dbml.DataClassesDataContext(this.ConnectionString))
            {
                #region Bulk Test...

                ////File.AppendAllText("WhenItStarted.txt", DateTime.Now.ToString());

                //for (int i = 2; i <= 1000; i++)
                //{

                //    item.Id = -2;

                //    Dbml.HtmlContent dbItem = db.HtmlContents.Where(x => x.Id == item.Id).SingleOrDefault();
                //    bool isNew = false;
                //    if (dbItem == null)
                //    {
                //        dbItem = new Dbml.HtmlContent();
                //        isNew = true;
                //    }

                //    dbItem.Name = item.Name;
                //    dbItem.ContentData = item.ContentData;
                //    dbItem.ActiveDate = item.ActiveDate;
                //    dbItem.ExpireDate = item.ExpireDate;
                //    dbItem.ModifiedBy = item.ModifiedBy;
                //    dbItem.ModifiedDate = item.ModifiedDate;


                //    if (isNew)
                //    {
                //        db.HtmlContents.InsertOnSubmit(dbItem);
                //    }
                //    try
                //    {
                //        db.SubmitChanges();
                //    }
                //    catch (Exception e)
                //    {
                //        string s = e.Message;
                //        throw;
                //    }
                //    item.Id = dbItem.Id;
                //}

                ////File.AppendAllText("WhenItStarted.txt", DateTime.Now.ToString());

                #endregion

                Dbml.HtmlContent dbItem = db.HtmlContents.Where(x => x.Id == entity.Id).SingleOrDefault();
                bool isNew = false;
                if (dbItem == null)
                {
                    dbItem = new Dbml.HtmlContent();
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
                dbItem.Name = entity.Name;
                dbItem.ContentData = entity.ContentData;
                dbItem.ActiveDate = entity.ActiveDate;
                dbItem.ExpireDate = entity.ExpireDate ;
                dbItem.ModifiedBy  = entity.ModifiedBy;
                dbItem.ModifiedDate = entity.ModifiedDate;
                dbItem.ItemState = (int)entity.ItemState;

                if (isNew)
                {
                    db.HtmlContents.InsertOnSubmit(dbItem);
                }
                db.SubmitChanges();

                entity.Id = dbItem.Id;
                return entity;
            }

        } 
        public bool Delete(Ent.HtmlContent entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
