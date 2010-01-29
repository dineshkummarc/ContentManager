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
    public class SqlSettingRepository : SqlBaseRepository, ISettingRepository
    {
        Dbml.DataClassesDataContext _db;

        public SqlSettingRepository(Dbml.DataClassesDataContext dataContext)
        {
            _db = dataContext;
        }

        #region IRepository<HtmlContent> Members

        public IQueryable<Ent.Setting> Get()
        {
            var setting = new List<Ent.Setting>();

            var r = this._db.Settings.Select(x => new
            {
                Application = x.Application, 
                Type = x.Type,
                Data = x.Data,
                ModifiedDate = x.ModifiedDate,
                ModifiedBy = x.ModifiedBy
            }).ToList();

            if (r.Count > 0)
            {
                var settingData = r.First(x => x.Application == "ContentManager");
                var serializer = new Serialization();

                setting.Add(serializer.Deserialize(settingData.Data, typeof(Setting).ToString()) as Setting);
            }

            return setting.AsQueryable();
        }

        public Ent.Setting Save(Ent.Setting item)
        {
            using (Dbml.DataClassesDataContext db = new Dbml.DataClassesDataContext(this.ConnStr))
            {
                var serializer = new Serialization();
                Dbml.Setting dbItem = db.Settings.Where(x => x.Application == "ContentManager").SingleOrDefault();
                bool isNew = false;
                if (dbItem == null)
                {
                    dbItem = new Dbml.Setting();
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
                dbItem.Application = "ContentManager";
                dbItem.Type = item.GetType().ToString();
                dbItem.Data = serializer.Serialize(item, item.GetType());
                dbItem.ModifiedBy = "Allen Racho";
                dbItem.ModifiedDate = DateTime.Now;

                if (isNew)
                {
                    db.Settings.InsertOnSubmit(dbItem);
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

                return item;
            }

        } 
        public bool Delete(Ent.Setting entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
