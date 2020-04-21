using System;
using System.Collections.Generic;

namespace RadiusCore.Models
{
    /// <summary>
    /// Radius HMI Things
    /// </summary>
    public class RadThingsModel
    {
        /// <summary>
        /// List of Radius HMI Things
        /// </summary>
        public Dictionary<Guid, RadThingModel> RadiusThings;

        /// <summary>
        /// Dictionary of Radius HMI Things. Key = ID
        /// </summary>
        public RadThingsModel()
        {
            RadiusThings = new Dictionary<Guid, RadThingModel>();
        }
    }

    /// <summary>
    /// Radius HMI Thing. Represents real world objects
    /// </summary>
    public class RadThingModel
    {
        
        /// <summary>
        /// Thing ID
        /// </summary>
        public Guid ID { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Display Name
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Thing Type ID used
        /// </summary>
        public Guid Type { get; set; }

        /// <summary>
        /// Properties associated with the Radius Thing
        /// </summary>
        public List<RadThingPropertyModel> Properties { get; set; } = new List<RadThingPropertyModel>();

        /// <summary>
        /// Write Security groups on the Thing
        /// </summary>
        public List<RadIdentifierModel> WriteSecurityLevel { get; set; }
    }

    /// <summary>
    /// Radius HMI Thing's Properties
    /// </summary>
    public class RadThingPropertyModel : RadIdentifierModel
    {
        /// <summary>
        /// Write Security groups on the Thing properties
        /// </summary>
        public List<RadIdentifierModel> WriteSecurityGroups { get; set; }
    }
}