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
                    Heading1 = "Test Heading1",
                    Heading2 = "Test Heading2",
                    Heading3 = "Test Heading3",
                    Id = 1,
                    LastName = "User1",
                    WebSiteLongURL = "www.longurl.com",
                    WebSiteShortURL = "bit.ly/12345"
                },
                new Expert()
                {
                    FirstName = "Test",
                    Heading1 = "Test Heading1",
                    Heading2 = "Test Heading2",
                    Heading3 = "Test Heading3",
                    Id = 1,
                    LastName = "User2",
                    WebSiteLongURL = "www.longurl.com",
                    WebSiteShortURL = "bit.ly/12345"
                },
                new Expert()
                {
                    FirstName = "Test",
                    Heading1 = "Test Heading1",
                    Heading2 = "Test Heading2",
                    Heading3 = "Test Heading3",
                    Id = 1,
                    LastName = "User3",
                    WebSiteLongURL = "www.longurl.com",
                    WebSiteShortURL = "bit.ly/12345"
                }
            };
        }

        [Test]
        public async Task ExecuteAsync()
        {
            foreach (var e in users)
            {
                await Lib.Data.DataService.AddAync<Expert>(e);
            }
            var allExperts = Lib.Data.DataService.GetAllAync<Expert>();
            Assert.IsTrue(allExperts.Count == users.Count);
        }

        [TearDown]
        public async Task TearDownAsync()
        {
            foreach (var u in users)
            {
                await Lib.Data.DataService.DeleteAsync<Expert>(u.Id);
            }
        }
    }
}