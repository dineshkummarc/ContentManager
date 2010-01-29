using Db4objects.Db4o.Linq;
//
using System;
using System.Linq;
//
using ContentNamespace.Web.Code.DataAccess.Interfaces;
using ContentNamespace.Web.Code.Util;
using ContentNamespace.Web.Code.Entities;

namespace ContentNamespace.Web.Code.DataAccess.Db4o
{
    public class Db4oSettingRepository  : ISettingRepository 
    {

        /// <summary>
        /// Returns all records of type T.
        /// </summary>
        public IQueryable<Setting> Get()
        {
            return (from Setting items in Db4O.Container
                    select items).AsQueryable();
        }

        /// <summary>
        /// Returns a PagedList of items.
        /// </summary>
        /// <param name="pageIndex">Zero-based index for lookup.</param>
        /// <param name="pageSize">Number of items to return in a page.</param>
        /// <returns></returns>
        public PagedList<Setting> GetPaged(int pageIndex, int pageSize)
        {
            var query = (from Setting items in Db4O.Container
                         select items).AsQueryable();

            return new PagedList<Setting>(query, pageIndex, pageSize);
        }

        /// <summary>
        /// Finds an item using a passed-in expression lambda.
        /// </summary>
        public IQueryable<Setting> Find(System.Linq.Expressions.Expression<Func<Setting, bool>> expression)
        {
            return Get().Where(expression);
        }

        /// <summary>
        /// Saves an item to the database.
        /// </summary>
        /// <param name="item">Item to save.</param>
        public Setting Save(Setting item)
        {
            Db4O.Container.Store(item);

            return item;
        }

        /// <summary>
        /// Deletes an item from the database.
        /// </summary>
        /// <param name="item">Item to delete.</param>
        public bool Delete(Setting item)
        {
            bool deleteSuccess = false;

            try
            {
                Db4O.Container.Delete(item);

                deleteSuccess = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return deleteSuccess;
        }
    }
}
