using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContentNamespace.Web.Code.DataAccess.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        T Save(T entity);
        bool Delete(T entity);
    }
}
