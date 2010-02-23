using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContentNamespace.Web.Code.DataAccess.Interfaces;
using ContentNamespace.Web.Code.Service.Interfaces;
using ContentNamespace.Web.Code.Service.ApplicationServices;
using ContentNamespace.Web.Code.DataAccess.Fake;

namespace ContentNamespace.Web.Tests.Services
{
    /// <summary>
    /// Summary description for BaseServiceTest
    /// </summary>
    [TestClass]
    public class BaseServiceTest
    {
        protected IHtmlContentRepository _ContentRepository;
        protected IHtmlContentService _ContentService;
        protected ISettingService _SettingService;
        protected IApplicationRepository _ApplicationRepository;
        protected IApplicationService _ApplicationService;


        [TestInitialize]
        public void Startup()
        { 
            _ApplicationRepository = new FakeApplicationRepository(); 
            _ApplicationService = new ApplicationService(this._ApplicationRepository); 
            _ContentRepository = new FakeHtmlContentRepository(this._ApplicationRepository);
            //_ContentService = new ContentService(this._ContentRepository, this._SettingService);
        }
        
    }
}
