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
                x.Name = "Name " + i  ; 
                x.Email = (i % 4 == 0) ? "joeshmo@yahoo.com" : (i % 3 == 0) ? "jimmyjones@gmail.com" : "bobbat@aol.com";
                x.ModifiedDate = new DateTime(2009, 1, 1);
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
