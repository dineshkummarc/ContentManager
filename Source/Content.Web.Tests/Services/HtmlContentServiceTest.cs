using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContentNamespace.Web.Code.Entities;

namespace ContentNamespace.Web.Tests.Services
{
    [TestClass]
    public class HtmlContentServiceTest : BaseServiceTest
    {

        [TestMethod]
        public void ContentService_Get_IsNotNull()
        { 
            IQueryable<HtmlContent> contents = this._ContentService.Get();
            Assert.IsNotNull(contents);
        }
        [TestMethod]
        public void ContentService_Get_ReturnsMoreThanZero()
        { 
            IQueryable<HtmlContent> contents = this._ContentService.Get();
            Assert.IsTrue(contents.Count() > 0);
        }
        [TestMethod]
        public void ContentService_GetById_HasCorrectData()
        { 
            HtmlContent content = this._ContentService.Get(1);
            Assert.IsTrue(content.ContentData.StartsWith("<p><img "));
        }

        [TestMethod]
        public void ContentService_SaveNewContent_ReturnsContent()
        { 
            HtmlContent content = new HtmlContent();
            content.ContentData = "a";
            HtmlContent content2 = this._ContentService.Save(content);
            Assert.AreEqual("a", content2.ContentData);
        }

    }
}
