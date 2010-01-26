using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using ContentNamespace.Web.Code.Entities;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using MongoDB.Driver.Bson;
using System.Runtime.Serialization.Formatters.Binary;
using ContentNamespace.Web.Code.Util;

namespace ContentNamespace.Web.Tests.Repositories
{
    /// <summary>
    /// Summary description for MongoDBRepository.
    /// </summary>
    [TestClass]
    public class MongoDBRepository
    {/*
        private static Mongo db = new Mongo();

        [ClassInitialize()]
        public static void MongoDBRepositoryInitialize(TestContext testContext) { db.Connect(); }

        [ClassCleanup()]
        public static void MongoDBRepositoryCleanup() 
        { 
            CleanTestDb();
  
            db.Disconnect(); 
        }

        [TestMethod]
        public void InsertObjectIntoDB_ObjectSerializedAndInserted()
        {
            HtmlContent c = new HtmlContent();

            c.Id = 1;
            c.ItemState = Enums.ContentState.InProgress;
            c.ContentData = @"<p>This is some <b>cool</b> content!</p>";
            c.CreatedBy = "Allen Racho";
            c.Name = "Test MongoDB Insert";
            c.ActiveDate = DateTime.Parse("2/2/2010");
            c.ExpireDate = DateTime.Parse("3/3/2010");

            IMongoCollection inserts = db["ContentManager"]["Content"];
            Document indoc = new Document();
            indoc["Id"] = "1";

            var serializer = new Serialization();
            var st = serializer.Serialize(c, c.GetType());

            indoc.Append("Data", st);

            inserts.Insert(indoc);

            Document result = inserts.FindOne(new Document().Append("Id", "1"));
            Assert.IsNotNull(result);
            Assert.AreEqual(1999, result["year"]);
        }

        [TestMethod]
        public void GetObjectFromDB_ObjectDeserializedAndRetrieved()
        {
            Document query = new Document();
            query["Id"] = "1";
            Document result = db["tests"]["inserts"].FindOne(query);
            Assert.IsNotNull(result);

            var serializer = new Serialization();
            var reader = result["Data"].ToString();
            HtmlContent c = serializer.Deserialize(reader, typeof(HtmlContent).ToString()) as HtmlContent;
        }

        [TestMethod]
        public void UpdateObjectAndSaveToDB_ObjectRetrievedModifiedThenSaved()
        {

        }

        protected static void CleanTestDb()
        {

        }*/
    }
}
