using Microsoft.Extensions.Configuration;
using System.IO;
using Newtonsoft.Json;
using RadiusCore.MongoDB;

namespace RadiusCore.Settings
{
    public static class MongoCollections
    {
        public static MongoDBCollections Settings { get; }
        static MongoCollections()
        {
            string fileName = Directory.GetCurrentDirectory() + "/Settings/MongoCollections.json";
            Settings = JsonConvert.DeserializeObject<MongoDBCollections>(File.ReadAllText(fileName));
        }
    }
}
