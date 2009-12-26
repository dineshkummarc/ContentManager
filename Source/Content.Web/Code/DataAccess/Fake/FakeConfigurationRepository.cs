using System.Collections.Generic;
using System.Linq;
//
using ContentNamespace.Web.Code.DataAccess.Interfaces;
using ContentNamespace.Web.Code.Entities;
using ContentNamespace.Web.Code.Util;

namespace ContentNamespace.Web.Code.DataAccess.Fake
{
    public class FakeConfigurationRepository : IConfigurationRepository
    {
        readonly IList<Settings> _list = new List<Settings>();

        #region IRepository<Settings> Members...

        public IQueryable<Settings> Get()
        {
            const string settingsData = @"<?xml version='1.0'?>
                <Settings xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'>
                  <GridPageSize>10</GridPageSize>
                  <ShowContentEllipsis>true</ShowContentEllipsis>
                  <ContentExtractLength>15</ContentExtractLength>
                  <AllowRejectedContentReActivation>false</AllowRejectedContentReActivation>
                  <AllowExpiredContentReActivation>true</AllowExpiredContentReActivation>
                </Settings>";

            var serializer = new Serialization();

            _list.Add(serializer.Deserialize(settingsData, typeof(Settings).ToString()) as Settings);

            return _list.AsQueryable();
        }

        public Settings Save(Settings entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Settings entity)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
