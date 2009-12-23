using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContentNamespace.Web.Code.Entities;
using ContentNamespace.Web.Code.DataAccess.Interfaces;

namespace ContentNamespace.Web.Code.DataAccess.Fake
{
    public class FakeUserProfileRepository: IUserProfileRepository
    {
        IList<UserProfile> list= new List<UserProfile>();

        public FakeUserProfileRepository()
        { 
            for (int i = 0; i < 5; i++ )
            {
                UserProfile x = new UserProfile();
                x.Name = "Name" + i  ;
                string email = (i % 4 == 0) ? "joeshmo" + i + "@yahoo.com" :
                    (i % 3 == 0) ? "jimmyjones" + i + "@gmail.com" : "bobbat" + i + "@aol.com";
                x.Email = email;
                x.UserName = email.Substring(0, email.IndexOf('@'));
                x.ModifiedDate = new DateTime(2009, 1, 1).AddDays(i);
                x.LastSignInDate = new DateTime(2009, 1, 1).AddDays(i);
                x.Id = i;
                list.Add(x);
            } 
        }



        public IQueryable<UserProfile> Get()
        {
            return list.AsQueryable<UserProfile>();
        }

        public UserProfile Save(UserProfile item)
        {
            if (item.Id > 0)
            {
                UserProfile w = this.list.Where(x => x.Id == item.Id).SingleOrDefault();
                if (w != null)
                {
                    w = item;
                }
                else
                {
                    list.Add(item);
                }
            }
            else
            {
                int maxId = this.list.Max(x => x.Id);
                item.Id = maxId + 1;
                this.list.Add(item);
            }
            return item;
        }


        public bool Delete(UserProfile entity)
        {
            throw new NotImplementedException();
        }

    }
}
