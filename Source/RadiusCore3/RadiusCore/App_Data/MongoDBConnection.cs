using MongoDB.Driver;
using MongoDB.Bson.Serialization.Conventions;
using RadiusCore.Settings;

namespace RadiusCore.App_Data
{
    public class MongoDBConnection
    {
        protected readonly MongoClient _client;
        protected readonly IMongoDatabase _db;

        public MongoDBConnection()
        {
            _client = new MongoClient(CustomAppSettings.Settings["MongoDB_Configuration:ConnectionString"]);
            _db = _client.GetDatabase(CustomAppSettings.Settings["MongoDB_Configuration:DatabaseName"]);
            var conventionPack = new ConventionPack { new IgnoreExtraElementsConvention(true) };
            ConventionRegistry.Register("IgnoreExtraElements", conventionPack, type => true);
        }
    }
}
