using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContentNamespace.Web.Code.DataAccess.Interfaces;
using ContentNamespace.Web.Code.Service.Interfaces;
using ContentNamespace.Web.Code.Service.ApplicationServices;
using ContentNamespace.Web.Code.DataAccess.Fake;
using ContentNamespace.Web.Code.Service.Base;

namespace ContentNamespace.Web.Tests.Services
{
    /// <summary>
    /// Summary description for BaseServiceTest
    /// </summary>
    [TestClass]
    public class BaseServiceTest
    {
        protected IContentRepository _ContentRepository;
        protected IContentService _ContentService;
        protected ISettingService _SettingService;
        protected IApplicationRepository _ApplicationRepository;
        protected IApplicationService _ApplicationService;


        [TestInitialize]
        public void Startup()
        { 
            _ApplicationRepository = new FakeApplicationRepository(); 
            _ApplicationService = new ApplicationService(this._ApplicationRepository); 
            _ContentRepository = new FakeContentRepository(this._ApplicationRepository);
            //_ContentService = new ContentService(this._ContentRepository, this._SettingService);
        }
        
    }
}
