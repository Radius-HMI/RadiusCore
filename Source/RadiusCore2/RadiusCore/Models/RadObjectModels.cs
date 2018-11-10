using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadiusCore.Models
{
    /// <summary>
    /// Radius HMI Objects
    /// </summary>
    public class RadObjectModels
    {
        /// <summary>
        /// List of Radius HMI Objects
        /// </summary>
        public Dictionary<Guid, RadObjectModel> RadiusObjects;

        /// <summary>
        /// Dictionary of Radius HMI Objects. Key = ID
        /// </summary>
        public RadObjectModels()
        {
            RadiusObjects = new Dictionary<Guid, RadObjectModel>();
        }
    }

    /// <summary>
    /// Radius HMI Object
    /// </summary>
    public class RadObjectModel
    {
        /// <summary>
        /// Object ID
        /// </summary>
        public Guid ID { get; set; }
        /// <summary>
        /// Display Name
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Object Type ID used
        /// </summary>
        public Guid Type { get; set; }
        /// <summary>
        /// Properties associated with the Radius Object
        /// </summary>
        public List<RadObjectPropertyModel> Properties { get; set; }
        /// <summary>
        /// Write Security groups on the object
        /// </summary>
        public List<RadIdentifierModel> WriteSecurityLevel { get; set; }
    }

    /// <summary>
    /// Radius HMI Object's Properties
    /// </summary>
    public class RadObjectPropertyModel : RadIdentifierModel
    {
        /// <summary>
        /// Write Security groups on the object properties
        /// </summary>
        public List<RadIdentifierModel> WriteSecurityGroups { get; set; }
    }
}
