using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadiusCore.Models
{/// <summary>
 /// Signals
 /// </summary>
    public class RadValueModels
    {
        /// <summary>
        /// List of Signals
        /// </summary>
        public Dictionary<Guid, RadValueModel> Signals;

        /// <summary>
        /// Creates new list
        /// </summary>
        public RadValueModels()
        {
            Signals = new Dictionary<Guid, RadValueModel>();
        }
    }
  

    /// <summary>
    /// Radius HMI Values
    /// </summary>
    public class RadValueModel
    {
        /// <summary>
        /// Object ID
        /// </summary>
        [Required]
        public Guid ID { get; set; }
        /// <summary>
        /// Object ID
        /// </summary>
        [Required]
        public Guid ObjectID { get; set; }
        /// <summary>
        /// Process Value representation - Also known as Tag Name
        /// </summary>
        [Required]
        public Guid PV { get; set; }
        /// <summary>
        /// Display Name
        /// </summary>
        [Required]
        public string Text { get; set; }
        /// <summary>
        /// Properties associated with the Radius Object
        /// </summary>
        public List<RadObjectPropertyModel> Properties { get; set; }
        /// <summary>
        /// DataType
        /// </summary>
        public Guid DataType { get; set; }
        /// <summary>
        /// Source of data
        /// </summary>
        [Required]
        public Guid Source { get; set; }
        /// <summary>
        /// Value of data point
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// TimeStamp
        /// </summary>
        [Required]
        public DateTime TimeStamp { get; set; }
        /// <summary>
        /// Enabled
        /// </summary>
        [Required]
        public bool Enabled { get; set; }
    }

    /// <summary>
    /// Radius HMI Value Properties
    /// </summary>
    public class RadValuePropertyModel : RadIdentifierModel
    {
        /// <summary>
        /// Write Security groups on the object properties
        /// </summary>
        public List<RadIdentifierModel> WriteSecurityGroups { get; set; }
    }
}
