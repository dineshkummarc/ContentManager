using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
//
using ContentNamespace.Web.Code.DataAccess.Fake;
using ContentNamespace.Web.Code.DataAccess.Interfaces;
using ContentNamespace.Web.Code.Service.AuthenticationServices;
using ContentNamespace.Web.Code.Service.Base;
using ContentNamespace.Web.Code.Service.ConfigurationServices;
using ContentNamespace.Web.Code.Service.Interfaces;
using ContentNamespace.Web.Code.Service.SystemServices;
using ContentNamespace.Web.Code.Service.UserProfileServices;
//
using Ninject.Core;
using Ninject.Core.Behavior;
using Ninject.Framework.Mvc;
using System.Web.Security;
using ContentNamespace.Web.Code.Service.MembershipServices;
using ContentNamespace.Web.Code.Service;
using ContentNamespace.Web.Code.Service.RoleServices;
using ContentNamespace.Web.Code.DataAccess.Db4o;
using ContentNamespace.Web.Code.DataAccess.VistaDb;
using ContentNamespace.Web.Code.DataAccess.Sql;

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
                "{controller}.mvc/{action}/{id}",                       // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            ); 
            routes.MapRoute(
                "Root",
                "",
                new { controller = "Home", action = "Index", id = "" }
            ); 
        }

        protected override IKernel CreateKernel()
        {
            var modules = new IModule[]
            {
                new AutoControllerModule(Assembly.GetExecutingAssembly()),
                //new ServiceModule()
                new Db4oModule()
            };
            return new StandardKernel(modules);
        }
    }


    internal class Db4oModule : StandardModule
    {
        public override void Load()
        {
            Bind<IContentRepository>().To<SqlContentRepository>().Using<SingletonBehavior>();
            //Bind<IContentRepository>().To<VistaDbContentRepository>().Using<SingletonBehavior>();
            //Bind<IContentRepository>().To<Db4oContentRepository>().Using<SingletonBehavior>();
            //Bind<IContentRepository>().To<MongoContentRepository>().Using<SingletonBehavior>();
            Bind<IContentService>().To<ContentService>();

            Bind<IUserProfileRepository>().To<FakeUserProfileRepository>().Using<SingletonBehavior>();// TODO: remove
            //Bind<IUserProfileRepository>().To<Db4oUserProfileRepository>().Using<SingletonBehavior>();// TODO: Implement
            Bind<IUserProfileService>().To<UserProfileService>();

            Bind<IAuthenticationService>().To<TestAuthenticationService>();

            Bind<ISettingRepository>().To<Db4oSettingRepository>().Using<SingletonBehavior>(); 
            Bind<ISettingService>().To<ConfigurationService>();

            Bind<ICacheService>().To<CacheService>();
            Bind<MembershipProvider>().To<SimpleMembershipProvider>();
            Bind<RoleProvider>().To<SimpleRoleProvider>();
        }
    }


    internal class ServiceModule : StandardModule
    {
        public override void Load()
        {
            Bind<IContentRepository>().To<FakeContentRepository>().Using<SingletonBehavior>();
            Bind<IContentService>().To<ContentService>();

            Bind<IUserProfileRepository>().To<FakeUserProfileRepository>().Using<SingletonBehavior>();
            Bind<IUserProfileService>().To<UserProfileService>();

            Bind<IAuthenticationService>().To<TestAuthenticationService>();

            Bind<ISettingRepository>().To<FakeSettingRepository>().Using<SingletonBehavior>();
            Bind<ISettingService>().To<ConfigurationService>();

            Bind<ICacheService>().To<CacheService>();
            Bind<MembershipProvider>().To<SimpleMembershipProvider>();
            Bind<RoleProvider>().To<SimpleRoleProvider>();
        }
    }
     
}








//Bind<IMembershipService>().To<AccountMembershipService>();
//Bind<IFormsAuthentication>().To<MockFormsAuthentication>();
//Bind<IIdentity>().To<MockIdentity>();
//Bind<IPrincipal>().To<MockPrincipal>();
//Bind<MembershipUser>().To<MockMembershipUser>();
//Bind<HttpContextBase>().To<MockHttpContext>();
//Bind<MembershipProvider>().To<MockMembershipProvider>();