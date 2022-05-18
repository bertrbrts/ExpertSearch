using JsonFlatFileDataStore;

namespace ExpertSearch.Lib.Data
{
    public class DataService
    {
        private static string _dataStore = "data.json";
        public static void Add<T>(object obj) where T : class
        {
            using var store = new DataStore(_dataStore);
            var collection = store.GetCollection<T>();
            collection.InsertOne((T)obj);
        }

        public static List<T> GetAll<T>() where T : class
        {
            using var store = new DataStore(_dataStore);
            var expertCollection = store.GetCollection<T>();
            return expertCollection.AsQueryable().ToList();
        }

        public static void Update<T>(int id, T obj) where T : class
        {
            using var store = new DataStore(_dataStore);
            var expertCollection = store.GetCollection<T>();
            expertCollection.UpdateOne(id, obj);
        }

        public static void Delete<T>(int Id) where T : class
        {
            using var store = new DataStore(_dataStore);
            var expertCollection = store.GetCollection<T>();
            expertCollection.DeleteOne(Id);
        }
    }
}