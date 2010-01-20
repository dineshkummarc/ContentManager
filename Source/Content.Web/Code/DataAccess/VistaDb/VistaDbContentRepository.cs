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
        //public int AddClient(Model.Client client)
        //{
        //    var newClient = new Client
        //    {
        //        ClientID = client.Id,
        //        ClientName = client.ClientName,
        //        DatabaseConnection = client.DatabaseConnection,
        //        Active = client.IsActive,
        //        TimeStamp = DateTime.Now
        //    };

        //    _context.AddToClient(newClient);
        //    _context.SaveChanges();

        //    return newClient.ClientID;
        //}

        //public bool UpdateClient(Model.Client client)
        //{
        //    var modifiedClient = _context.Client.First(e => e.ClientID == client.Id);

        //    modifiedClient.ClientName = client.ClientName;
        //    modifiedClient.DatabaseConnection = client.DatabaseConnection;
        //    modifiedClient.Active = client.IsActive;
        //    modifiedClient.TimeStamp = DateTime.Now;

        //    _context.ObjectStateManager.GetObjectStateEntry(modifiedClient.EntityKey).SetModified();

        //    try
        //    {
        //        _context.SaveChanges();

        //        return true;
        //    }
        //    catch (OptimisticConcurrencyException) { return false; }
        //}

        //public bool DeleteClient(int clientId)
        //{
        //    var clientToDelete = _context.Client.First(e => e.ClientID == clientId);

        //    try
        //    {
        //        _context.Attach(clientToDelete);
        //        _context.DeleteObject(clientToDelete);
        //        _context.SaveChanges();

        //        return true;
        //    }
        //    catch { return false; }
        //}

        #region IContentRepositoryMembers...

        public IQueryable<ContentNamespace.Web.Code.Entities.HtmlContent> Get()
        {
            _context = new ContentManagerEntities();

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
                            ExpireDate = r.ExpireData,
                            ActiveDate = r.ActiveDate,
                            OwnerUserId = (int)r.OwnerUserId
                        };

            return query.AsQueryable();
        }

        public ContentNamespace.Web.Code.Entities.HtmlContent Save(ContentNamespace.Web.Code.Entities.HtmlContent entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ContentNamespace.Web.Code.Entities.HtmlContent entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
