﻿using System;
using System.Linq;
//
using ContentNamespace.Web.Code.Service.Base;
using ContentNamespace.Web.Code.DataAccess.Interfaces;
using ContentNamespace.Web.Code.Entities;

namespace ContentNamespace.Web.Code.Service.UserProfileServices
{
    public class UserProfileService : ContentManagerBaseService, IUserProfileService
    {
        private IUserProfileRepository _repository;

        public UserProfileService(IUserProfileRepository _rep)
        {
            _repository = _rep;
            _settings = _service.GetFromCache(Resources.EN.Strings.System_ContentManagerSettingsCacheKey) as Settings;
        }

        public IQueryable<UserProfile> Get(DateTime dt)
        {
            return null;
        }

        /// <summary>
        /// when you get all then just get a substring for the UserProfile data
        /// </summary>
        /// <returns></returns>
        public IQueryable<UserProfile> Get()
        {
            //var contents = this._repository.Get().Select(x => new UserProfile
            //{
            //    Id = x.Id,
            //    Name = x.Name, 
            //    ModifiedBy = x.ModifiedBy,
            //    ModifiedDate = x.ModifiedDate
            //});
            //return contents;
            return ((IContentManagerBaseService)this).GetData() as IQueryable<UserProfile>;
        }

        public UserProfile Get(int id)
        {
            return this._repository.Get().Where(x => x.Id == id).Single<UserProfile>();
        }

        public UserProfile Save(UserProfile item)
        {
            return this._repository.Save(item);
        }

        public bool Delete(UserProfile item)
        {
            return false;
        }

        #region IContentManagerBaseService Members...

        object IContentManagerBaseService.GetData()
        {
            return this._repository.Get();
        }

        #endregion
    }

}
