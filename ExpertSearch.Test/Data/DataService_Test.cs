using ExpertSearch.Lib;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpertSearch.Test.Data
{
    [TestFixture]
    internal class DataService_Test
    {
        private static List<Expert> users = new() { };

        [SetUp]
        public void Setup()
        {
            users = new List<Expert>
            {
                new Expert()
                {
                    FirstName = "Test",
                    Heading1 = new List<string>{ "Test Heading1" },
                    Heading2 = new List<string>{ "Test Heading2" },
                    Heading3 = new List<string>{ "Test Heading3" },
                    Id = 1,
                    LastName = "User1",
                    WebSiteLongURL = "www.longurl.com",
                    WebSiteShortURL = "bit.ly/12345"
                },
                new Expert()
                {
                    FirstName = "Test",
                    Heading1 = new List<string>{ "Test Heading1" },
                    Heading2 = new List<string>{ "Test Heading2" },
                    Heading3 = new List<string>{ "Test Heading3" },
                    Id = 1,
                    LastName = "User2",
                    WebSiteLongURL = "www.longurl.com",
                    WebSiteShortURL = "bit.ly/12345"
                },
                new Expert()
                {
                    FirstName = "Test",
                    Heading1 = new List<string>{ "Test Heading1" },
                    Heading2 = new List<string>{ "Test Heading2" },
                    Heading3 = new List<string>{ "Test Heading3" },
                    Id = 1,
                    LastName = "User3",
                    WebSiteLongURL = "www.longurl.com",
                    WebSiteShortURL = "bit.ly/12345"
                }
            };
        }

        [Test]
        public void Execute()
        {
            foreach (var e in users)
            {
                Lib.Data.DataService.Add<Expert>(e);
            }
            var allExperts = Lib.Data.DataService.GetAll<Expert>();
            Assert.IsTrue(allExperts.Count == users.Count);
        }

        [TearDown]
        public void TearDownAsync()
        {
            foreach (var u in users)
            {
                Lib.Data.DataService.Delete<Expert>(u.Id);
            }
        }
    }
}