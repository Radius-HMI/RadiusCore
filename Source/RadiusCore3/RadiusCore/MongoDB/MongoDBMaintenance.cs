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
    /// Maintenance Object for collection trimming and index creation
    /// </summary>
    public class MongoDBMaintenance : MongoDBConnection
    {
        private readonly MongoDBCollections _mongoDBCollections = MongoCollections.Settings;

        /// <summary>
        /// Build any collection indexes configured
        /// </summary>
        /// <returns></returns>
        public void BuildIndexes()
        {
            foreach(string collection in _mongoDBCollections.Collections.Keys)
            {
                BuildCollections(collection);
            }
        }

        private void BuildCollections(string collectionName)
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
                    newCollection.Indexes.CreateOneAsync(indexModel);
                }
            }
        }
    }
}
