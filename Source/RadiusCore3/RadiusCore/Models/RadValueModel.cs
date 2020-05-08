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
        public Dictionary<String, RadValueModel> Signals;

        /// <summary>
        /// Creates new list
        /// </summary>
        public RadValueModels()
        {
            Signals = new Dictionary<String, RadValueModel>();
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
        public string ID { get; set; } = Guid.NewGuid().ToString();



        /// <summary>
        /// Thing ID
        /// </summary>
        [Required]
        public string ThingID { get; set; }

        /// <summary>
        /// Process Value representation - Also known as Tag Name
        /// </summary>
        public string PV { get; set; }

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
        public string DataType { get; set; } 

        /// <summary>
        /// Source of data
        /// </summary>
        [Required]
        public string Source { get; set; }

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