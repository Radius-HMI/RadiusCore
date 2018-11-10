using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using RadiusCore.Models;
using RadiusCore.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadiusCore.MongoDB
{
    /// <summary>
    /// Maintenance Object for Collection Creation and trimming
    /// </summary>
    public class Maintenance
    {
        private readonly MongoDBCollections _mongoDBCollections;

        /// <summary>
        /// Collection Configuration according to appsettings.json
        /// </summary>
        /// <param name="mongoDBCollections"></param>
        public Maintenance(MongoDBCollections mongoDBCollections)
        {
            _mongoDBCollections = mongoDBCollections;
            _client = new MongoClient(CustomAppSettings.Settings["MongoDB_Configuration:ConnectionString"]);
            _db = _client.GetDatabase(CustomAppSettings.Settings["MongoDB_Configuration:DatabaseName"]);
        }

        readonly MongoClient _client;
        readonly IMongoDatabase _db;

        public async Task BuildIndexesAsync()
        {
            foreach(string collection in _mongoDBCollections.Collections.Keys)
            {
                await BuildIndexes(collection);
            }
        }

        private async Task BuildIndexes(string collectionName)
        {
            BsonDocument filter = new BsonDocument("name", collectionName);
            ListCollectionNamesOptions namesToFind = new ListCollectionNamesOptions { Filter = filter };
            //*** If the collection doesn't exist, create it
            if (!_db.ListCollectionNames(namesToFind).Any())
            {
                //*** Create collection and index
                IMongoCollection<BsonDocument> newCollection = _db.GetCollection<BsonDocument>(collectionName);
                //*** Create Indexes
                for (int i = 0; i < _mongoDBCollections.Collections[collectionName].Count; i++)
                {
                    CreateIndexOptions options = new CreateIndexOptions()
                    {
                        Unique = _mongoDBCollections.Collections[collectionName][i].Unique
                    };
                    CreateIndexModel<BsonDocument> indexModel = 
                        new CreateIndexModel<BsonDocument>(new BsonDocument {
                                { _mongoDBCollections.Collections[collectionName][i].Field,
                                    _mongoDBCollections.Collections[collectionName][i].Direction }
                            }, options);
                    await newCollection.Indexes.CreateOneAsync(indexModel);
                }
            }
        }
    }
}
