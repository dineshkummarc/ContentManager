using System.Collections.Generic;
using System.Linq;
//
using ContentNamespace.Web.Code.DataAccess.Interfaces;
using ContentNamespace.Web.Code.Entities;
using ContentNamespace.Web.Code.Util;

namespace ContentNamespace.Web.Code.DataAccess.Fake
{
    public class FakeSettingRepository : ISettingRepository
    {
        readonly IList<Setting> _list = new List<Setting>();
         

        public FakeSettingRepository()
        { 
            const string settingsData = @"<?xml version='1.0'?>
                <Setting xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'>
                  <SettingsCacheTimeInMinutes>5</SettingsCacheTimeInMinutes>
                  <GridPageSize>10</GridPageSize>
                  <ShowContentEllipsis>true</ShowContentEllipsis>
                  <ContentExtractLength>15</ContentExtractLength>
                  <AllowRejectedContentReActivation>false</AllowRejectedContentReActivation>
                  <AllowExpiredContentReActivation>true</AllowExpiredContentReActivation>
                </Setting>";
            var serializer = new Serialization();
            _list.Add(serializer.Deserialize(settingsData, typeof(Setting).ToString()) as Setting);

        }


        #region IRepository<Settings> Members...

        public IQueryable<Setting> Get()
        { 
            return _list.AsQueryable();
        }

        public Setting Save(Setting item)
        {
            Setting repItem = this._list.Where(x => x.Id == item.Id).SingleOrDefault();
            if (repItem != null)
            {
                this._list.Remove(repItem);
            }
            else
            {
                int maxId = this._list.Max(x => x.Id);
                item.Id = maxId + 1;
            }
            this._list.Add(item);
            return item; 
        }

        public bool Delete(Setting entity)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
