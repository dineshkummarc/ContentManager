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

        public ContentNamespace.Web.Code.Entities.HtmlContent Save(ContentNamespace.Web.Code.Entities.HtmlContent entity)
        {
            var modifiedContent = _context.HtmlContent.First(e => e.Id == entity.Id);

            //modifiedClient.CreatedDate = entity.CreatedDate; // Invariant
            //modifiedClient.CreatedBy = entity.CreatedBy; // Invariant
            modifiedContent.ModifiedDate = DateTime.Now;
            modifiedContent.ModifiedBy = entity.ModifiedBy;
            //modifiedClient.ItemState = entity.ItemState.ToString();
            modifiedContent.Name = entity.Name;
            modifiedContent.ContentData = entity.ContentData;
            modifiedContent.ExpireDate = entity.ExpireDate;
            modifiedContent.ActiveDate = entity.ActiveDate;
            modifiedContent.OwnerUserId = entity.OwnerUserId;

            _context.ObjectStateManager.GetObjectStateEntry(modifiedContent.EntityKey).SetModified();

            try
            {
                _context.SaveChanges();

                return entity;
            }
            catch (OptimisticConcurrencyException) { return null; }
        }

        public bool Delete(ContentNamespace.Web.Code.Entities.HtmlContent entity)
        {
            var contentToDelete = _context.HtmlContent.First(e => e.Id == entity.Id);

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
