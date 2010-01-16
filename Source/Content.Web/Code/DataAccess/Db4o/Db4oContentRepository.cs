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
    public class Db4oContentRepository  : IContentRepository 
    {

        /// <summary>
        /// Returns all records of type T.
        /// </summary>
        public IQueryable<HtmlContent> Get()
        {
            return (from HtmlContent items in Db4O.Container
                    select items).AsQueryable();
        }

        /// <summary>
        /// Returns a PagedList of items.
        /// </summary>
        /// <param name="pageIndex">Zero-based index for lookup.</param>
        /// <param name="pageSize">Number of items to return in a page.</param>
        /// <returns></returns>
        public PagedList<HtmlContent> GetPaged(int pageIndex, int pageSize)
        {
            var query = (from HtmlContent items in Db4O.Container
                         select items).AsQueryable();

            return new PagedList<HtmlContent>(query, pageIndex, pageSize);
        }

        /// <summary>
        /// Finds an item using a passed-in expression lambda.
        /// </summary>
        public IQueryable<HtmlContent> Find(System.Linq.Expressions.Expression<Func<HtmlContent, bool>> expression)
        {
            return Get().Where(expression);
        }

        /// <summary>
        /// Saves an item to the database.
        /// </summary>
        /// <param name="item">Item to save.</param>
        public HtmlContent Save(HtmlContent item)
        {
            HtmlContent w = Get().Where(x => x.Id == item.Id).SingleOrDefault();

            if (w != null)
            {
                Delete(w);
            }
            else
            {
                int maxId = (Get().Count() > 0) ? Get().Max(x => x.Id) : 0;
                item.Id = maxId + 1;
            }

            Db4O.Container.Store(item);

            return item;
        }

        /// <summary>
        /// Deletes an item from the database.
        /// </summary>
        /// <param name="item">Item to delete.</param>
        public bool Delete(HtmlContent item)
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
