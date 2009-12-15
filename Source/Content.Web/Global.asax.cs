using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject.Core;
using Ninject.Framework.Mvc;
using NinjectIntegration.Models;
using Content.Web.Code.Service.Interfaces;
using Content.Web.Code.DataAccess.Interfaces;
using Content.Web.Code.Service.Base;
using Content.Web.Code.DataAccess.Fake;

namespace Content.Web
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
            Bind<IGreetingService>().To<GreetingServiceImpl>();
            Bind<IContentRepository>().To<FakeContentRepository>();
            //Bind<IContentService>().To<ContentServiceImpl>();
            Bind<IContentService>().To<ContentService>();
        }
    }
}