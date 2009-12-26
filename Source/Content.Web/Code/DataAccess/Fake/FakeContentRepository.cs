using System;
using System.Collections.Generic;
using System.Linq;
using ContentNamespace.Web.Code.DataAccess.Interfaces;
//using Ent = Content.Web.Code.Entities;
using ContentNamespace.Web.Code.Entities;


namespace ContentNamespace.Web.Code.DataAccess.Fake
{

    public class FakeContentRepository : IContentRepository
    {

        IList<HtmlContent> list = new List<HtmlContent>();

        public FakeContentRepository()
        {
            for (int i = 0; i < 5; i++)
            {
                HtmlContent x = new HtmlContent();
                x.Name = "Name " + i;
                x.ContentData = "<h1>Hello " + i + " </h1>" +
                @"<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus bibendum, nisl a vestibulum lobortis, urna libero rutrum odio, ut auctor dui mi quis est. Aliquam enim nulla, dictum vitae viverra eu, pretium ut sem. Nunc porttitor fringilla tortor, vestibulum lobortis turpis tempus eu. Aliquam erat volutpat. Nam ut sollicitudin nisl. Etiam a quam vel urna aliquam pellentesque. Praesent dignissim ante a augue imperdiet dapibus. Morbi varius, ipsum vestibulum vehicula dapibus, enim nunc hendrerit justo, id porta erat urna vel augue. Nulla cursus, odio non mattis cursus, libero justo dignissim turpis, sit amet luctus lorem sapien non neque. Mauris pretium sem eget eros pharetra venenatis. Sed eu est a quam consectetur iaculis. Quisque tincidunt iaculis massa, eu vehicula ipsum varius ac. Cras blandit, eros sit amet porttitor varius, ipsum tortor interdum metus, in viverra nisi ante sed magna. Nulla sodales vulputate aliquet. Etiam ornare lobortis quam tincidunt aliquet. Aliquam in viverra orci.</p>" +
                @"<p>Sed semper, mauris sit amet auctor egestas, ante libero faucibus orci, a tempor augue eros consequat dolor. Duis euismod ante sem. Vivamus pretium pharetra ullamcorper. Aenean convallis commodo erat vitae vehicula. Nam et dictum sapien. Pellentesque rhoncus dapibus eros, vel blandit justo egestas at. Fusce eu est mi, vel consequat odio. Donec adipiscing massa sollicitudin massa tempor cursus. Etiam aliquet varius suscipit. Pellentesque tristique, eros quis accumsan mollis, sapien erat molestie sapien, eget ultricies nisi erat vel erat. Nullam vel est massa. In hac habitasse platea dictumst. Aenean tincidunt consectetur arcu. Aenean fringilla tempor arcu, placerat fringilla nisl accumsan sit amet. Suspendisse tincidunt, purus in eleifend mattis, ante justo dictum dolor, non auctor ligula mauris ac nisl. Fusce tempus, nisl a feugiat malesuada, nisi tellus rhoncus nunc, sed pellentesque risus justo sed enim. Suspendisse in dolor elit. Nullam dignissim interdum risus ac tempus. Morbi vehicula luctus metus, ut ullamcorper nunc vestibulum id.</p>"; 
                x.ActiveDate = DateTime.MinValue;
                x.ModifiedBy = (i % 4 == 0) ? "joeshmo@yahoo.com" : (i % 3 == 0) ? "jimmyjones@gmail.com" : "bobbat@aol.com";
                x.ModifiedDate = new DateTime(2009, 1, 1);
                x.Id = i;
                list.Add(x);
            }
        }




        public IQueryable<HtmlContent> Get()
        {
            return list.AsQueryable<HtmlContent>();
        }

        public HtmlContent Save(HtmlContent item)
        {
            if (item.Id > 0)
            {
                HtmlContent w = this.list.Where(x => x.Id == item.Id).SingleOrDefault();
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


        public bool Delete(HtmlContent entity)
        {
            throw new NotImplementedException();
        }

    }
}