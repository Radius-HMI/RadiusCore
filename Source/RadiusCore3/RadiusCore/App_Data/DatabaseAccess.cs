using RadiusCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadiusCore.App_Data
{
    /// <summary>
    /// Databases supported
    /// </summary>
    public enum Databases
    {
        MongoDB
    }

    /// <summary>
    /// Database access for maintained Radius HMI object state
    /// </summary>
    public class DatabaseAccess
    {
        Databases _database;
        MongoDBAccess _mongo;
        public DatabaseAccess(Databases database = Databases.MongoDB)
        {
            _database = database;
            switch (_database)
            {
                case Databases.MongoDB:

                    _mongo = new MongoDBAccess();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Get a Radius HMI Thing
        /// </summary>
        /// <param name="identifierID"></param>
        /// <returns></returns>
        public async Task<RadThingsModel> GetThingAsync(string identifierID)
        {
            switch (_database)
            {
                case Databases.MongoDB:
                    return await _mongo.GetThingAsync(identifierID);
                default:
                    return null;
            }
        }

        /// <summary>
        /// Get Radius HMI Things
        /// </summary>
        /// <param name="typeID"></param>
        /// <returns></returns>
        public async Task<RadThingsModel> GetThingsAsync(string typeID)
        {
            switch (_database)
            {
                case Databases.MongoDB:
                    return await _mongo.GetThingAsync(typeID);
                default:
                    return null;
            }
        }

        /// <summary>
        /// Get Radius HMI Things
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public async Task PutThingAsync(RadThingModel identifier)
        {
            switch (_database)
            {
                case Databases.MongoDB:
                    await _mongo.AddThingAsync(identifier);
                    break;
                default:
                    break;
            }
        }

        public async Task<bool> UpdateThingAsync(RadThingModel identifier){
            switch (_database)
            {
                case Databases.MongoDB:
                    return await _mongo.UpdateThingAsync(identifier);
                default:
                    return false;
            }
        }

        
        public async Task<bool> DeleteThingAsync(string identifierID){
            switch (_database)
            {
                case Databases.MongoDB:
                    return await _mongo.DeleteThingAsync(identifierID);
                default:
                    return false;
            }
        }

        /// <summary>
        /// Get Radius HMI Identifiers
        /// </summary>
        /// <param name="identifierID"></param>
        /// <returns></returns>
        public async Task<List<RadIdentifierModel>> GetIdentifiersAsync(string identifierID)
        {
            switch (_database)
            {
                case Databases.MongoDB:
                    return await _mongo.GetIdentifiersAsync(identifierID);
                default:
                    return null;
            }
        }

        /// <summary>
        /// Get Radius HMI Identifier
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public async Task PutIdentifierAsync(RadIdentifierModel identifier)
        {
            switch (_database)
            {
                case Databases.MongoDB:
                    await _mongo.AddIdentifierAsync(identifier);
                    break;
                default:
                    break;
            }
        }

        public async Task<bool> UpdateIdentifierAsync(RadIdentifierModel identifier){
            switch (_database)
            {
                case Databases.MongoDB:
                    return await _mongo.UpdateIdentifierAsync(identifier);
                default:
                    return false;
            }
        }
        
        public async Task<bool> DeleteIdentifierAsync(string identifierID){
            switch (_database)
            {
                case Databases.MongoDB:
                    return await _mongo.DeleteIdentifierAsync(identifierID);
                default:
                    return false;
            }
        }

    }
    
}
