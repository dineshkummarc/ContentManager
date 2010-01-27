using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentNamespace.Web.Code.DataAccess.Interfaces;
using ContentNamespace.Web.Code.Entities;
using Ent = ContentNamespace.Web.Code.Entities;
using Dbml = ContentNamespace.Web.Code.DataAccess.Sql.Dbml;

namespace ContentNamespace.Web.Code.DataAccess.Sql
{
    public class SqlContentRepository : SqlBaseRepository, IContentRepository
    {

        Dbml.DataClassesDataContext _db;

        public SqlContentRepository(Dbml.DataClassesDataContext dataContext)
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
                CreatedDate = x.CreatedDate ?? new DateTime(1753, 1, 1),
                ItemState = GetContentStateEnum((int)x.ItemState)
            }).AsQueryable();
            return r;
        }

        private Enums.ContentState GetContentStateEnum(int? intValue)
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

        public Ent.HtmlContent Save(Ent.HtmlContent item)
        {
            using (Dbml.DataClassesDataContext db = new Dbml.DataClassesDataContext(this.ConnStr))
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

                Dbml.HtmlContent dbItem = db.HtmlContents.Where(x => x.Id == item.Id).SingleOrDefault();
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
                dbItem.Name = item.Name;
                dbItem.ContentData = item.ContentData;
                dbItem.ActiveDate = item.ActiveDate;
                dbItem.ExpireDate = item.ExpireDate ;
                dbItem.ModifiedBy  = item.ModifiedBy;
                dbItem.ModifiedDate = item.ModifiedDate;
                dbItem.ItemState = (int)item.ItemState;

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
