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
            int i = 0;
            while ( i < 2)
            {
                UserProfile x = new UserProfile();
                x.Name = "Name" + i  ;
                string email = (i % 4 == 0) ? "joeshmo" + i + "@yahoo.com" :
                    (i % 3 == 0) ? "jimmyjones" + i + "@gmail.com" : "bobbat" + i + "@aol.com";
                x.Email = email;
                x.UserRoles.Add(Enums.UserRoles.Reader);
                x.UserRoles.Add(Enums.UserRoles.Contributor);
                x.UserRoles.Add(Enums.UserRoles.Admin);
                x.UserName = email.Substring(0, email.IndexOf('@'));
                x.OpenIdId = email.Substring(0, email.IndexOf('@'));
                x.ModifiedDate = new DateTime(2008, 1, 1).AddDays(i);
                x.LastSignInDate = new DateTime(2008, 1, 1).AddDays(i);
                x.Id = i;
                list.Add(x);
                i++;
            }
            list.Add(CreateUser(i++, "nick", "eiu165", "eiu165",
                "https://www.google.com/accounts/o8/id?id=AItOawmH6AK8ncGX-hJTjiAABt7MMw72e2stcD4",
                new List<Enums.UserRoles> { Enums.UserRoles.Admin, Enums.UserRoles.Contributor})); 
        }

        private UserProfile CreateUser(int id, string name, string username, 
            string email, string openIdId, 
            List<Enums.UserRoles>roles)
        {
            UserProfile u = new UserProfile();
            u.Id = id;
            u.Name = name;
            u.Email = email;
            u.OpenIdId = openIdId;
            foreach (Enums.UserRoles ur in roles)
            {
                u.UserRoles.Add(ur);
            }
            return u;
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
