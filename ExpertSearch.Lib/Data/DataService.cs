using JsonFlatFileDataStore;

namespace ExpertSearch.Lib.Data
{
    public class DataService
    {
        private static string _dataStore = "data.json";
        public static async Task AddAync<T>(object obj) where T : class
        {
            using var store = new DataStore(_dataStore);
            var collection = store.GetCollection<T>();
            await collection.InsertOneAsync((T)obj);
        }

        public static List<T> GetAllAync<T>() where T : class
        {
            using var store = new DataStore(_dataStore);
            var expertCollection = store.GetCollection<T>();
            return expertCollection.AsQueryable().ToList();
        }

        public static async Task DeleteAsync<T>(int Id) where T : class
        {
            using var store = new DataStore(_dataStore);
            var expertCollection = store.GetCollection<T>();
            await expertCollection.DeleteOneAsync(Id);
        }
    }
}