using System.Collections.Generic;

namespace RadiusCore.App_Data
{
    public class MongoDBCollections
    {
        public Dictionary<string, List<MongoDBIndex>> Collections { get; set; }
    }
    public class MongoDBIndex
    {
        public string Field { get; set; }
        public int Direction { get; set; }
        public bool Unique { get; set; }
    }
}
