using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject.Core;
using Ninject.Framework.Mvc; 
using ContentNamespace.Web.Code.Service.Interfaces;
using ContentNamespace.Web.Code.DataAccess.Interfaces;
using ContentNamespace.Web.Code.Service.Base;
using ContentNamespace.Web.Code.DataAccess.Fake;
using Ninject.Core.Behavior;
using ContentNamespace.Web.Controllers;
using ContentNamespace.Web.Code.Service.Fake;
using System.Security.Principal;
using System.Web.Security;

namespace ContentNamespace.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : NinjectHttpApplication
    {
        protected override void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );
        }

        protected override IKernel CreateKernel()
        {
            IModule[] modules = new IModule[]
            {
                new AutoControllerModule(Assembly.GetExecutingAssembly()),
                new ServiceModule()
            };
            return new StandardKernel(modules);
        }
    }

    internal class ServiceModule : StandardModule
    {
        public override void Load()
        {
            Bind<IContentRepository>().To<FakeContentRepository>().Using<SingletonBehavior>();
            Bind<IContentService>().To<ContentService>();
            //return new StandardKernel(modules);         


            //Bind<IMembershipService>().To<AccountMembershipService>();
            //Bind<IFormsAuthentication>().To<MockFormsAuthentication>();
            //Bind<IIdentity>().To<MockIdentity>();
            //Bind<IPrincipal>().To<MockPrincipal>();
            //Bind<MembershipUser>().To<MockMembershipUser>();
            //Bind<HttpContextBase>().To<MockHttpContext>();
            //Bind<MembershipProvider>().To<MockMembershipProvider>(); 
        }
    }
     
}