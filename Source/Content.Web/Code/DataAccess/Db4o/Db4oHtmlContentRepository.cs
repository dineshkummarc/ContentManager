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
    public class Db4oHtmlContentRepository  : IHtmlContentRepository 
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
        public PagedList<HtmlContent> Get(int pageIndex, int pageSize, out int totalCount)
        {
            var resultSet = new PagedList<HtmlContent>(Get(), pageIndex, pageSize);
            totalCount = resultSet.TotalCount;

            return resultSet;
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
            #region Bulk Test...

            //File.AppendAllText("WhenItStarted.txt", DateTime.Now.ToString());

            //for (int i = 2; i <= 1000; i++)
            //{
            //    HtmlContent newItem = new HtmlContent();

            //    newItem.Name = item.Name + " " + i;
            //    newItem.ModifiedBy = item.ModifiedBy;//TODO: should be loged in user
            //    newItem.ModifiedDate = DateTime.Now;
            //    newItem.ExpireDate = item.ExpireDate;
            //    newItem.ActiveDate = new DateTime(1900, 1, 1);
            //    newItem.ContentData = item.ContentData;
            //    newItem.CreatedBy = item.CreatedBy;//TODO: should be loged in user
            //    newItem.CreatedDate = item.CreatedDate;

            //    newItem.Id = i;

            //    HtmlContent w = Get().Where(x => x.Id == newItem.Id).SingleOrDefault();


            //    if (w != null)
            //    {
            //        Delete(w);
            //    }
            //    else
            //    {
            //        int maxId = (Get().Count() > 0) ? Get().Max(x => x.Id) : 0;
            //        newItem.Id = maxId + 1;
            //    }

            //    Db4O.Container.Store(newItem);
            //}

            //File.AppendAllText("WhenItStarted.txt", DateTime.Now.ToString());

            #endregion

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
