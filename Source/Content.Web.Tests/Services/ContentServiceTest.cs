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
            IQueryable<HtmlContent> contents = cs.GetContent();
            Assert.IsNotNull(contents);
        }
        [TestMethod]
        public void ContentService_Get_ReturnsMoreThanZero()
        {
            ContentService cs = new ContentService(new FakeContentRepository());
            IQueryable<HtmlContent> contents = cs.GetContent();
            Assert.IsTrue(contents.Count() > 0);
        }
        [TestMethod]
        public void ContentService_GetById_HasCorrectData()
        {
            ContentService cs = new ContentService(new FakeContentRepository());
            HtmlContent content = cs.GetContent(1);
            Assert.AreEqual( "<h1>Hello 1 </h1>" ,content.ContentData);
        }

        [TestMethod]
        public void ContentService_SaveNewContent_ReturnsContent()
        {
            ContentService cs = new ContentService(new FakeContentRepository());
            HtmlContent content = new HtmlContent();
            content.ContentData = "a";
            HtmlContent content2 = cs.Save(content);
            Assert.AreEqual("a", content2.ContentData);
        }

    }
}
