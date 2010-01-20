using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ContentNamespace.Web.Code.DataAccess.Interfaces;
using ContentNamespace.Web.Code.Entities;

namespace ContentNamespace.Web.Code.DataAccess.VistaDb
{
    public class VistaDbContentRepository : VistaDb, IContentRepository
    {
        public VistaDbContentRepository()
        {
            _context = new ContentManagerEntities();
        }

        #region IContentRepositoryMembers...

        public IQueryable<ContentNamespace.Web.Code.Entities.HtmlContent> Get()
        {
            var query = from r in _context.HtmlContent
                        select new ContentNamespace.Web.Code.Entities.HtmlContent
                        {
                            Id = r.Id,
                            CreatedDate = r.CreatedDate,
                            CreatedBy = r.CreatedBy,
                            ModifiedDate = (DateTime)r.ModifiedDate,
                            ModifiedBy = r.ModifiedBy,
                            //ItemState = (Enums.ContentState)Enum.Parse(typeof(Enums.ContentState), r.ItemState),
                            Name = r.Name,
                            ContentData = r.ContentData,
                            ExpireDate = r.ExpireDate,
                            ActiveDate = r.ActiveDate,
                            OwnerUserId = (int)r.OwnerUserId
                        };

            return query.AsQueryable();
        }

        public ContentNamespace.Web.Code.Entities.HtmlContent Save(ContentNamespace.Web.Code.Entities.HtmlContent content)
        {
            if (content.Id > 0)
            {
                var modifiedContent = _context.HtmlContent.First(e => e.Id == content.Id);

                modifiedContent.CreatedDate = content.CreatedDate;
                modifiedContent.CreatedBy = content.CreatedBy;
                modifiedContent.ModifiedDate = DateTime.Now;
                modifiedContent.ModifiedBy = content.ModifiedBy;
                //modifiedContent.ItemState = entity.ItemState.ToString();
                modifiedContent.Name = content.Name;
                modifiedContent.ContentData = content.ContentData;
                modifiedContent.ExpireDate = content.ExpireDate;
                modifiedContent.ActiveDate = content.ActiveDate;
                modifiedContent.OwnerUserId = content.OwnerUserId;

                _context.ObjectStateManager.GetObjectStateEntry(modifiedContent.EntityKey).SetModified();
            }
            else
            {
                int maxId = (Get().Count() > 0) ? Get().Max(x => x.Id) : 0;
                content.Id = maxId + 1;

                var newContent = new HtmlContent
                {
                    Id = content.Id,
                    CreatedDate = DateTime.Now,
                    CreatedBy = string.IsNullOrEmpty(content.CreatedBy) ? string.Empty : content.CreatedBy,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = content.ModifiedBy,
                    //ItemState = entity.ItemState.ToString(),
                    Name = content.Name,
                    ContentData = content.ContentData,
                    ExpireDate = content.ExpireDate,
                    ActiveDate = content.ActiveDate,
                    OwnerUserId = content.OwnerUserId
                };

                _context.AddToHtmlContent(newContent);
                _context.SaveChanges();

                return content;
            }

            try
            {
                _context.SaveChanges();

                return content;
            }
            catch (OptimisticConcurrencyException) { return null; }
        }

        public bool Delete(ContentNamespace.Web.Code.Entities.HtmlContent content)
        {
            var contentToDelete = _context.HtmlContent.First(e => e.Id == content.Id);

            try
            {
                _context.Attach(contentToDelete);
                _context.DeleteObject(contentToDelete);
                _context.SaveChanges();

                return true;
            }
            catch { return false; }
        }

        #endregion
    }
}
