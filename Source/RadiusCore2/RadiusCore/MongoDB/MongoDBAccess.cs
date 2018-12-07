using MongoDB.Bson;
using MongoDB.Driver;
using RadiusCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadiusCore.MongoDB
{
    public class MongoDBAccess : MongoDBConnection
    {
        readonly Guid _nullGuid;

        /// <summary>
        /// Get a Radius HMI Thing
        /// </summary>
        /// <param name="thingID"></param>
        /// <returns></returns>
        public async Task<RadThingsModel> GetThingAsync(Guid thingID)
        {
            RadThingsModel things = new RadThingsModel();
            IMongoCollection<RadThingModel> collection = _db.GetCollection<RadThingModel>(TableNames.Things);
            if (thingID != _nullGuid)
            {
                FilterDefinition<RadThingModel> filter = Builders<RadThingModel>.Filter.Eq(x => x.ID.ToString(), "ID");
                using (IAsyncCursor<RadThingModel> cursor = await collection.FindAsync(filter))
                {
                    while (await cursor.MoveNextAsync())
                    {
                        IEnumerable<RadThingModel> batch = cursor.Current;
                        foreach (RadThingModel thing in batch)
                        {
                            things.RadiusThings.Add(thing.ID, thing);
                        }
                    }
                }
            }
            return things;
        }

        /// <summary>
        /// Get Radius HMI Things
        /// </summary>
        /// <param name="typeID"></param>
        /// <returns></returns>
        public async Task<RadThingsModel> GetThingsAsync(Guid typeID)
        {
            RadThingsModel things = new RadThingsModel();
            IMongoCollection<RadThingModel> collection = _db.GetCollection<RadThingModel>(TableNames.Things);
            FilterDefinition<RadThingModel> filter = FilterDefinition<RadThingModel>.Empty;
            if (typeID != _nullGuid)
            {
                filter = Builders<RadThingModel>.Filter.Eq(x => x.Type.ToString(), "Type");
            }
            using (IAsyncCursor<RadThingModel> cursor = await collection.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    IEnumerable<RadThingModel> batch = cursor.Current;
                    foreach (RadThingModel thing in batch)
                    {
                        things.RadiusThings.Add(thing.ID, thing);
                    }
                }
            }
            return things;
        }

        /// <summary>
        /// Add a new Radius Thing
        /// </summary>
        /// <param name="thing"></param>
        /// <returns></returns>
        public async Task AddThingsAsync(RadThingModel thing)
        {
            IMongoCollection<RadThingModel> collection = _db.GetCollection<RadThingModel>(TableNames.Things);
            await collection.InsertOneAsync(thing);
        }
    }
}
