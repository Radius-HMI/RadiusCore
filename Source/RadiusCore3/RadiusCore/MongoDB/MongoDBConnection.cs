using MongoDB.Driver;
using RadiusCore.Settings;

namespace RadiusCore.MongoDB
{
    public class MongoDBConnection
    {
        protected readonly MongoClient _client;
        protected readonly IMongoDatabase _db;

        public MongoDBConnection()
        {
            _client = new MongoClient(CustomAppSettings.Settings["MongoDB_Configuration:ConnectionString"]);
            _db = _client.GetDatabase(CustomAppSettings.Settings["MongoDB_Configuration:DatabaseName"]);
        }
    }
}
