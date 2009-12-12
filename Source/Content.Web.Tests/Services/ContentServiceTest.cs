using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Content.Web.Code.Service.Base;
using Content.Web.Code.Entities;
using Content.Web.Code.DataAccess.Fake;

namespace Content.Web.Tests.Services
{
    [TestClass]
    public class ContentServiceTest
    { 

        [TestMethod]
        public void ContentService_Get_IsNotNull()
        {
            ContentService cs = new ContentService(new FakeContentRepository());
            IQueryable<HtmlContent> contents =  cs.GetContent();
            Assert.IsNotNull(contents);
        }
    }
}
