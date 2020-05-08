using MongoDB.Bson;
using MongoDB.Driver;
using RadiusCore.Models;
using RadiusCore.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadiusCore.App_Data
{
    public class MongoDBAccess : MongoDBConnection
    {
        /// <summary>
        /// Get a Radius HMI Thing
        /// </summary>
        /// <param name="thingID"></param>
        /// <returns></returns>
        public async Task<RadThingsModel> GetThingAsync(string thingID)
        {
            RadThingsModel things = new RadThingsModel();
            IMongoCollection<RadThingModel> collection = _db.GetCollection<RadThingModel>(TableNames.Things);
            if (collection == null)
            {
                MongoDBMaintenance buildCollections = new MongoDBMaintenance();
            }
            FilterDefinition<RadThingModel> filter = FilterDefinition<RadThingModel>.Empty;
            if (thingID != string.Empty.ToString() && !string.IsNullOrWhiteSpace(thingID))
            {
                filter = Builders<RadThingModel>.Filter.Eq(x => x.ID, thingID);
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
        /// Get a Radius HMI Identifier
        /// </summary>
        /// <param name="thingID"></param>
        /// <returns></returns>
        public async Task<List<RadIdentifierModel>> GetIdentifiersAsync(string identifierID)
        {
            List<RadIdentifierModel> identifiers = new List<RadIdentifierModel>();
            IMongoCollection<RadIdentifierModel> collection = _db.GetCollection<RadIdentifierModel>(TableNames.Identifiers);
            if (collection == null)
            {
                MongoDBMaintenance buildCollections = new MongoDBMaintenance();
            }
            FilterDefinition<RadIdentifierModel> filter = FilterDefinition<RadIdentifierModel>.Empty;
            if (identifierID != string.Empty.ToString() && !string.IsNullOrWhiteSpace(identifierID))
            {
                filter = Builders<RadIdentifierModel>.Filter.Eq(x => x.ID, identifierID);
            }
            using (IAsyncCursor<RadIdentifierModel> cursor = await collection.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    IEnumerable<RadIdentifierModel> batch = cursor.Current;
                    foreach (RadIdentifierModel identifier in batch)
                    {
                        identifiers.Add(identifier);
                    }
                }
            }
            return identifiers;
        }

        /// <summary>
        /// Get Radius HMI Things
        /// </summary>
        /// <param name="typeID"></param>
        /// <returns></returns>
        public async Task<RadThingsModel> GetThingsAsync(string typeID)
        {
            RadThingsModel things = new RadThingsModel();
            IMongoCollection<RadThingModel> collection = _db.GetCollection<RadThingModel>(TableNames.Things);
            FilterDefinition<RadThingModel> filter = FilterDefinition<RadThingModel>.Empty;
            if (typeID != Guid.Empty.ToString() && !string.IsNullOrWhiteSpace(typeID))
            {
                filter = Builders<RadThingModel>.Filter.Eq(x => x.ID.ToString(), typeID);
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
        public async Task AddThingAsync(RadThingModel thing)
        {
            IMongoCollection<RadThingModel> collection = _db.GetCollection<RadThingModel>(TableNames.Things);
            await collection.InsertOneAsync(thing);
            Console.WriteLine("Putting Thing");
        }

        /// <summary>
        /// Update a Radius Thing
        /// </summary>
        /// <param name="thing"></param>
        /// <returns></returns>
        public async Task<bool> UpdateThingAsync(RadThingModel thing)
        {
            IMongoCollection<RadThingModel> collection = _db.GetCollection<RadThingModel>(TableNames.Things);
            ReplaceOneResult result = await collection.ReplaceOneAsync(x => x.ID == thing.ID, thing);
            return result.IsAcknowledged;
        }

        /// <summary>
        /// Get a Radius HMI Thing
        /// </summary>
        /// <param name="thingID"></param>
        /// <returns></returns>
        public async Task<bool> DeleteThingAsync(string thingID)
        {
            IMongoCollection<RadThingModel> collection = _db.GetCollection<RadThingModel>(TableNames.Things);
            if (string.IsNullOrWhiteSpace(thingID) || collection == null)
            {
                return false;
            }
            FilterDefinition<RadThingModel> filter = Builders<RadThingModel>.Filter.Eq(x => x.ID, thingID);
            DeleteResult result = await collection.DeleteOneAsync(filter);
            return result.IsAcknowledged;
        }

        /// <summary>
        /// Add a new Radius Identifier
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public async Task AddIdentifierAsync(RadIdentifierModel identifier)
        {
            IMongoCollection<RadIdentifierModel> collection = _db.GetCollection<RadIdentifierModel>(TableNames.Identifiers);
            await collection.InsertOneAsync(identifier);
            Console.WriteLine("Putting Identifier");
        }

        /// <summary>
        /// Update a Radius Identifier
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public async Task<bool> UpdateIdentifierAsync(RadIdentifierModel identifier)
        {
            IMongoCollection<RadIdentifierModel> collection = _db.GetCollection<RadIdentifierModel>(TableNames.Identifiers);
            ReplaceOneResult result = await collection.ReplaceOneAsync(x => x.ID == identifier.ID, identifier);
            return result.IsAcknowledged;
        }

        /// <summary>
        /// Get a Radius HMI Identifier
        /// </summary>
        /// <param name="identifierID"></param>
        /// <returns></returns>
        public async Task<bool> DeleteIdentifierAsync(string identifierID)
        {
            IMongoCollection<RadIdentifierModel> collection = _db.GetCollection<RadIdentifierModel>(TableNames.Identifiers);
            if (string.IsNullOrWhiteSpace(identifierID) || collection == null)
            {
                return false;
            }
            FilterDefinition<RadIdentifierModel> filter = Builders<RadIdentifierModel>.Filter.Eq(x => x.ID, identifierID);
            DeleteResult result = await collection.DeleteOneAsync(filter);
            return result.IsAcknowledged;
        }
    }
}
