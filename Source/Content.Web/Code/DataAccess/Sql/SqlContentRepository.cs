using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentNamespace.Web.Code.DataAccess.Interfaces;
using Ent = ContentNamespace.Web.Code.Entities;
using Sql = ContentNamespace.Web.Code.DataAccess.Sql;

namespace ContentNamespace.Web.Code.DataAccess.Sql
{
    public class SqlContentRepository : SqlBaseRepository, IContentRepository
    {

        Sql.DataClassesDataContext _db;

        public SqlContentRepository(Sql.DataClassesDataContext dataContext)
        {
            _db = dataContext;
        }
         

        #region IRepository<HtmlContent> Members

        public IQueryable<Ent.HtmlContent> Get()
        {
            var r = this._db.HtmlContents.Select(x => new Ent.HtmlContent
            {
                Id = x.Id,
                Name = x.Name, 
                ContentData = x.ContentData,
                ActiveDate = x.ActiveDate ?? new DateTime(1753, 1,1),
                ExpireDate = x.ExpireDate ?? new DateTime(1753, 1, 1),
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate ?? new DateTime(1753, 1, 1)  
            }).AsQueryable();
            return r;
        }

        public Ent.HtmlContent Save(Ent.HtmlContent item)
        {
            using (DataClassesDataContext db = new DataClassesDataContext(this.ConnStr))
            {
                HtmlContent dbItem = db.HtmlContents.Where(x => x.Id == item.Id).SingleOrDefault();
                bool isNew = false;
                if (dbItem == null)
                {
                    dbItem = new HtmlContent();
                    isNew = true;
                }
                //else
                //{
                //    //remove them for refresh
                //    //wish there was a better way to do this but... 
                //    //db.TalentEvents.DeleteAllOnSubmit(db.TalentEvents.Where(x => x.TalentID == t.Id));
                //    //db.TalentLanguages.DeleteAllOnSubmit(db.TalentLanguages.Where(x => x.TalentID == t.Id));
                //    //db.TalentTypeTalents.DeleteAllOnSubmit(db.TalentTypeTalents.Where(x => x.TalentID == t.Id));

                //    //db.TalentFiles.DeleteAllOnSubmit(db.TalentFiles.Where(x => x.TalentID == t.Id));
                //    //db.TalentStates.DeleteAllOnSubmit(db.TalentStates.Where(x => x.TalentID == t.Id)); 
                //}
                //foreach (Model.Model.TalentEvent tdb in t.TalentEvents)
                //{
                //    SqlServer.TalentEvent dbTe = new SqlServer.TalentEvent();
                //    dbTe.TalentID = t.Id;
                //    dbTe.EventID = tdb.EventID;
                //    dbT.TalentEvents.Add(dbTe);
                //} 
                dbItem.Name = item.Name;
                dbItem.ContentData = item.ContentData;
                dbItem.ActiveDate = item.ActiveDate;
                dbItem.ExpireDate = item.ExpireDate ;
                dbItem.ModifiedBy  = item.ModifiedBy;
                dbItem.ModifiedDate = item.ModifiedDate;


                if (isNew)
                {
                    db.HtmlContents.InsertOnSubmit(dbItem);
                }
                try
                {
                    db.SubmitChanges();
                }
                catch (Exception e)
                {
                    string s = e.Message;
                    throw;
                }
                item.Id = dbItem.Id;
                return item;
            }

        }
        /*
         
            using (SqlTalentDataContext db = new SqlTalentDataContext(this.ConnStr))
            {
                Aspen.TalentManager.Data.DataAccess.SqlServer.Talent dbT =
                    db.Talents.Where(x => x.TalentID == t.Id).SingleOrDefault();
                bool isNew = false;
                if (dbT == null)
                {
                    dbT = new SqlServer.Talent();
                    isNew = true;
                }
                else
                {
                    //remove them for refresh
                    //wish there was a better way to do this but... 
                    db.TalentEvents.DeleteAllOnSubmit(db.TalentEvents.Where(x => x.TalentID == t.Id));
                    db.TalentLanguages.DeleteAllOnSubmit(db.TalentLanguages.Where(x => x.TalentID == t.Id));
                    db.TalentTypeTalents.DeleteAllOnSubmit(db.TalentTypeTalents.Where(x => x.TalentID == t.Id));
                     
                    //db.TalentFiles.DeleteAllOnSubmit(db.TalentFiles.Where(x => x.TalentID == t.Id));
                    //db.TalentStates.DeleteAllOnSubmit(db.TalentStates.Where(x => x.TalentID == t.Id)); 
                }

                foreach (Model.Model.TalentEvent tdb in t.TalentEvents)
                {
                    SqlServer.TalentEvent dbTe = new SqlServer.TalentEvent();
                    dbTe.TalentID = t.Id;
                    dbTe.EventID = tdb.EventID;
                    dbT.TalentEvents.Add(dbTe);
                }
                foreach (Model.Model.TalentLanguage tl in t.TalentLanguages)
                {
                    SqlServer.TalentLanguage dbTl = new SqlServer.TalentLanguage();
                    dbTl.TalentID = t.Id;
                    dbTl.LanguageID = tl.LanguageId;
                    dbT.TalentLanguages.Add(dbTl);
                }
                foreach (Model.Model.TalentTalentType ttt in t.TalentTalentTypes)
                {
                    SqlServer.TalentTypeTalent dbTtt = new SqlServer.TalentTypeTalent();
                    dbTtt.TalentID = t.Id;
                    dbTtt.TypeTalentID = ttt.TalentTypeId;
                    dbT.TalentTypeTalents.Add(dbTtt);
                    //dbTtt.TypeTalent.Add(dbTtt);
                }
                foreach (Model.Model.TalentEvent te in t.TalentFiles)
                {
                    SqlServer.TalentEvent dbTe = new SqlServer.TalentEvent();
                    dbTe.TalentID = t.Id;
                    dbTe.EventID = te.EventID;
                    dbT.TalentEvents.Add(dbTe);
                }
                foreach (Model.Model.TalentState ts in t.TalentStates)
                {
                    SqlServer.TalentState dbTs = new SqlServer.TalentState();
                    dbTs.TalentID = t.Id;
                    dbTs.SPRID = ts.SPRID;
                    dbT.TalentStates.Add(dbTs);
                }
                dbT.FirstName = t.FirstName;
                dbT.LastName = t.LastName; 
                dbT.MiddleName = t.MiddleName;
                dbT.Address2 = t.Address2;
                dbT.Country = t.Country;
                dbT.WebsiteOther = t.WebsiteOther;
                dbT.AltEmail2 = t.AltEmail2; 

                dbT.City = t.City;
                dbT.DateOfBirth = DateTimeUtil.GetDate(t.DateOfBirth);
                dbT.TalentStatusID = (t.TalentStatusID <= 0) ? (int)TalentStatusEnum.New : (int?)t.TalentStatusID;
                dbT.UserName = t.UserName;
                dbT.Email = t.Email;
                dbT.AltEmail1 = t.AltEmail1;
                dbT.AltEmail2 = t.AltEmail2;
                dbT.GenderID = (t.GenderID <= 0) ? null : (int?)t.GenderID;
                dbT.RaceID = (t.RaceID <= 0) ? null : (int?)t.RaceID;
                dbT.HomePhone = t.HomePhone;
                dbT.WorkPhone = t.WorkPhone;
                dbT.CellPhone = t.CellPhone;
                dbT.Address1 = t.Address1;
                dbT.City = t.City;
                dbT.StateID = (t.StateId <= 0)? null : (int?)t.StateId ;
                dbT.ZipCode = t.ZipCode;
                dbT.Country = t.Country ;
                dbT.Hear = t.Hear;
                dbT.Availability = t.Availability;
                dbT.Rating = t.Rating;
                dbT.StageName = t.StageName; 
                dbT.TourWork = t.TourWork;
                dbT.Transportation = t.Transportation;
                dbT.HeightFeet = (t.HeightFeet <= 0) ? null : (int?)t.HeightFeet;
                dbT.HeightInches = (t.HeightInches <= 0) ? null : (int?)t.HeightInches;
                dbT.Weight = t.Weight;
                dbT.ShirtSizeID = (t.ShirtSizeID <= 0) ? null : (int?)t.ShirtSizeID;
                dbT.EyeColorID = (t.EyeColorID <= 0) ? null : (int?)t.EyeColorID;
                dbT.HairColorID = (t.HairColorID <= 0) ? null : (int?)t.HairColorID;
                dbT.Website = t.Website;
                dbT.WebsiteOther = t.WebsiteOther;
                dbT.DemoReel = t.DemoReel;
                dbT.Experience = t.Experience;
                dbT.Notes = t.Notes;
                dbT.Active = t.Active;
                //dbT.DateCreated = t.DateCreated;
                dbT.UserId = t.UserId;
                dbT.Company = t.Company;
                dbT.FileNumber = t.FileNumber;
                dbT.Password = t.Password;
                 
                if (isNew)
                {
                    db.Talents.InsertOnSubmit(dbT);
                }
                try
                {
                    db.SubmitChanges();
                }
                catch (Exception e)
                {
                    string s = e.Message;
                    throw;
                }
                t.Id = dbT.TalentID;   
            }
         */

        public bool Delete(Ent.HtmlContent entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
