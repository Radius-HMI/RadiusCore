using RadiusCore.Models;
using RadiusCore.MongoDB;
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
        /// <param name="thingID"></param>
        /// <param name="typeID"></param>
        /// <returns></returns>
        public async Task<RadThingsModel> GetThingAsync(Guid thingID)
        {
            switch (_database)
            {
                case Databases.MongoDB:
                    return await _mongo.GetThingAsync(thingID);
                default:
                    return null;
            }
        }

        /// <summary>
        /// Get Radius HMI Things
        /// </summary>
        /// <param name="thingID"></param>
        /// <param name="typeID"></param>
        /// <returns></returns>
        public async Task<RadThingsModel> GetThingsAsync(Guid typeID)
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
        /// <param name="thingID"></param>
        /// <param name="typeID"></param>
        /// <returns></returns>
        public async Task PutThingAsync(RadThingModel thing)
        {
            switch (_database)
            {
                case Databases.MongoDB:
                    await _mongo.AddThingAsync(thing);
                    break;
                default:
                    break;
            }
        }

    }
    
}
