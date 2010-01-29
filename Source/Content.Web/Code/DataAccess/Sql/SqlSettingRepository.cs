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
        string applicationName = "Blackhawk";
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
                var settingData = r.First(x => x.Application.Name == applicationName);
                var serializer = new Serialization();

                setting.Add(serializer.JsonDeserialize<Setting>(settingData.Data));
            }

            return setting.AsQueryable();
        }

        public Ent.Setting Save(Ent.Setting item)
        {
            using (Dbml.DataClassesDataContext db = new Dbml.DataClassesDataContext(this.ConnStr))
            {
                var serializer = new Serialization();
                Dbml.Setting dbItem = db.Settings.Where(x => x.Application.Name == applicationName).SingleOrDefault();
                bool isNew = false;

                if (dbItem == null)
                {
                    dbItem = new Dbml.Setting();
                    isNew = true;
                }
 
                dbItem.ApplicationId = _db.Applications.Where(x => x.Name == applicationName).Single().Id;
                dbItem.Type = item.GetType().ToString();
                dbItem.Data = serializer.JsonSerialize(item);
                dbItem.ModifiedBy = item.ModifiedBy;
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
