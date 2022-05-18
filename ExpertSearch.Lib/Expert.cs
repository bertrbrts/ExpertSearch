using JsonFlatFileDataStore;

namespace ExpertSearch.Lib
{
    public class Expert
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Heading1 { get; set; }
        public string Heading2 { get; set; }
        public string Heading3 { get; set; }
        public string WebSiteLongURL { get; set; }
        public string WebSiteShortURL { get; set; }

        public async Task AddAync()
        {
            using var store = new DataStore("data.json");
            var collection = store.GetCollection<Expert>();
            await collection.InsertOneAsync(this);
        }
    }
}