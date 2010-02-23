using System;
using System.Linq;
//
using AutoMapper;
//
using ContentNamespace.Web.Code.DataAccess.Interfaces;
using ContentNamespace.Web.Code.Util;
using HtmlContent=ContentNamespace.Web.Code.Entities.HtmlContent;

namespace ContentNamespace.Web.Code.DataAccess.Sql
{
    public class SqlHtmlContentRepository : SqlBaseRepository, IHtmlContentRepository
    {
        public PagedList<HtmlContent> Get(int pageIndex, int pageSize, out int totalCount) 
        {
            var query = new PagedList<HtmlContent>(Get(), pageIndex, pageSize);

            totalCount = query.TotalCount;

            return query;
        }

        #region IRepository<HtmlContent> Members

        public IQueryable<HtmlContent> Get()
        {
            using (var db = new Dbml.DataClassesDataContext(ConnectionString))
            {
                // TODO: This is a somewhat strange usage, and should be looked into; if we don't convert to a list
                // first, then we get an exception as the DataContext has been disposed by the time the IQueryable is
                // materialized "later on"; however, if we do convert to a list, this is an extra processing hit
                return db.HtmlContents.Select(x => Mapper.Map<Dbml.HtmlContent, HtmlContent>(x))
                    .ToList()
                    .AsQueryable();
            }
        }

        public HtmlContent Save(HtmlContent entity)
        {
            using (var db = new Dbml.DataClassesDataContext(ConnectionString))
            {
                #region Bulk Test...

                ////File.AppendAllText("WhenItStarted.txt", DateTime.Now.ToString());

                //for (int i = 2; i <= 1000; i++)
                //{

                //    item.Id = -2;

                //    Dbml.HtmlContent dbItem = db.HtmlContents.Where(x => x.Id == item.Id).SingleOrDefault();
                //    bool isNew = false;
                //    if (dbItem == null)
                //    {
                //        dbItem = new Dbml.HtmlContent();
                //        isNew = true;
                //    }

                //    dbItem.Name = item.Name;
                //    dbItem.ContentData = item.ContentData;
                //    dbItem.ActiveDate = item.ActiveDate;
                //    dbItem.ExpireDate = item.ExpireDate;
                //    dbItem.ModifiedBy = item.ModifiedBy;
                //    dbItem.ModifiedDate = item.ModifiedDate;


                //    if (isNew)
                //    {
                //        db.HtmlContents.InsertOnSubmit(dbItem);
                //    }
                //    try
                //    {
                //        db.SubmitChanges();
                //    }
                //    catch (Exception e)
                //    {
                //        string s = e.Message;
                //        throw;
                //    }
                //    item.Id = dbItem.Id;
                //}

                ////File.AppendAllText("WhenItStarted.txt", DateTime.Now.ToString());

                #endregion

                Dbml.HtmlContent dbItem = db.HtmlContents.Where(x => x.Id == entity.Id).SingleOrDefault();
                bool isNew = false;

                if (dbItem == null)
                {
                    dbItem = new Dbml.HtmlContent();
                    isNew = true;
                }

                // Map from Domain => DataContext
                Mapper.Map(entity, dbItem);

                if (isNew)
                {
                    db.HtmlContents.InsertOnSubmit(dbItem);
                }

                db.SubmitChanges();

                entity.Id = dbItem.Id;
                
                return entity;
            }

        }

        public bool Delete(HtmlContent entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
