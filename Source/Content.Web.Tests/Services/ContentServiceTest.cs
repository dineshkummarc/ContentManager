﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContentNamespace.Web.Code.Service.Base;
using ContentNamespace.Web.Code.Entities;
using ContentNamespace.Web.Code.DataAccess.Fake;

namespace ContentNamespace.Web.Tests.Services
{
    [TestClass]
    public class ContentServiceTest : BaseServiceTest
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
