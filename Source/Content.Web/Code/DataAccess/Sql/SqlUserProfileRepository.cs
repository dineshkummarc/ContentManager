using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentNamespace.Web.Code.DataAccess.Interfaces;
using Ent = ContentNamespace.Web.Code.Entities;
using Sql = ContentNamespace.Web.Code.DataAccess.Sql;
using ContentNamespace.Web.Code.Util;

namespace ContentNamespace.Web.Code.DataAccess.Sql
{
    public class SqlUserProfileRepository : SqlBaseRepository, IUserProfileRepository 
    {
        
        Sql.DataClassesDataContext _db;

        public SqlUserProfileRepository(Sql.DataClassesDataContext dataContext)
        {
            _db = dataContext;
        }
         


        #region IRepository<UserProfile> Members

        public IQueryable<Ent.UserProfile> Get()
        {
            var r = this._db.UserProfiles.Select(x => new Ent.UserProfile
            {
                Id = x.Id,
                Name = x.Name,
                UserName = x.UserName,
                Email = x.Email,
                LastSignInDate = x.LastSignInDate ?? new DateTime(1753, 1, 1),
                OpenIdId = x.OpenIdId,
                RegisterDate = x.RegisterDate ?? new DateTime(1753, 1, 1),
                UserRoles = new LazyList<Ent.Enums.UserRoles>(),
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate ?? new DateTime(1753, 1, 1),
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate ?? new DateTime(1753, 1, 1)
            }).AsQueryable();
            return r;
        }

        public Ent.UserProfile Save(Ent.UserProfile item)
        {
            using (DataClassesDataContext db = new DataClassesDataContext(this.ConnStr))
            {
                UserProfile dbItem = db.UserProfiles.Where(x => x.Id == item.Id).SingleOrDefault();
                bool isNew = false;
                if (dbItem == null)
                {
                    dbItem = new UserProfile();
                    isNew = true;
                }
                else
                {
                    //remove them for refresh
                    //wish there was a better way to do this but... 
                    db.Application_UserProfiles.DeleteAllOnSubmit
                    (
                        db.Application_UserProfiles.Where(x => x.UserProfileId ==  item.Id)
                    );
                } 
                foreach( Ent.Application a in item.Applications)
                {
                    Sql.Application_UserProfile dbAppUser = new Application_UserProfile();
                    dbAppUser.UserProfileId = item.Id;
                    dbAppUser.ApplicationId = a.Id;
                    dbItem.Application_UserProfiles.Add(dbAppUser);
                }
                dbItem.Name = item.Name;
                dbItem.Email = item.Email;
                dbItem.LastSignInDate = item.LastSignInDate;
                dbItem.OpenIdId = item.OpenIdId;
                dbItem.RegisterDate = item.RegisterDate;
                dbItem.UserName = item.UserName;
                dbItem.ModifiedBy = item.ModifiedBy;
                dbItem.ModifiedDate = item.ModifiedDate;
                dbItem.CreatedDate = item.CreatedDate;
                dbItem.CreatedBy = item.CreatedBy;


                if (isNew)
                {
                    db.UserProfiles.InsertOnSubmit(dbItem);
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

        public bool Delete(Ent.UserProfile entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
