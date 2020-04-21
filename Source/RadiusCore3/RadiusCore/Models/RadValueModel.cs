using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        /// Thing ID
        /// </summary>
        [Required]
        public Guid ID { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Thing ID
        /// </summary>
        [Required]
        public Guid ThingID { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Process Value representation - Also known as Tag Name
        /// </summary>
        [Required]
        public Guid PV { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Display Name
        /// </summary>
        [Required]
        public string Text { get; set; }

        /// <summary>
        /// Properties associated with the Radius Thing
        /// </summary>
        public List<RadThingPropertyModel> Properties { get; set; }

        /// <summary>
        /// DataType
        /// </summary>
        public Guid DataType { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Source of data
        /// </summary>
        [Required]
        public Guid Source { get; set; } = Guid.NewGuid();

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
        /// Write Security groups on the Thing properties
        /// </summary>
        public List<RadIdentifierModel> WriteSecurityGroups { get; set; }
    }
}