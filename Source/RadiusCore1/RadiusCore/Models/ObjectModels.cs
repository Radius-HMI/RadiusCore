using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RadiusCore.Models
{
    /// <summary>
    /// Radius Objects
    /// </summary>
    public class ObjectModels
    {
        /// <summary>
        /// List of Radius Objects
        /// </summary>
        public List<ObjectModel> RadiusObjects;

        /// <summary>
        /// Creates new list
        /// </summary>
        public ObjectModels()
        {
            RadiusObjects = new List<ObjectModel>();
        }
    }

    /// <summary>
    /// Radius Object
    /// </summary>
    public class ObjectModel
    {
        /// <summary>
        /// Object ID
        /// </summary>
        public string ObjectID { get; set; }
        /// <summary>
        /// Display Name
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// Object Type ID used
        /// </summary>
        public string ObjectTypeID { get; set; }
        /// <summary>
        /// Object Type Value
        /// </summary>
        public string ObjectTypeValue { get; set; }
        /// <summary>
        /// Object Type Text used for display
        /// </summary>
        public string ObjectTypeText { get; set; }
    }

    /// <summary>
    /// Radius Objects
    /// </summary>
    public class ObjectPropertiesModels
    {
        /// <summary>
        /// List of Radius Objects
        /// </summary>
        public List<ObjectPropertyModel> RadiusObjectProperties;

        /// <summary>
        /// Creates new list
        /// </summary>
        public ObjectPropertiesModels()
        {
            RadiusObjectProperties = new List<ObjectPropertyModel>();
        }
    }

    /// <summary>
    /// Radius Object's Properties
    /// </summary>
    public class ObjectPropertyModel
    {
        /// <summary>
        /// Property ID
        /// </summary>
        public string PropertyID { get; set; }
        /// <summary>
        /// Object ID associated with the properties
        /// </summary>
        [Required]
        public string ObjectID { get; set; }
        /// <summary>
        /// Property Name
        /// </summary>
        [Required]
        public string PropertyName { get; set; }
        /// <summary>
        /// Display Value
        /// </summary>
        [Required]
        public string DisplayName { get; set; }
        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Data Type ID
        /// </summary>
        [Required]
        public string DataTypeID { get; set; }
        /// <summary>
        /// Data Type Text
        /// </summary>
        public string DataTypeText { get; set; }
        /// <summary>
        /// Data Type Value
        /// </summary>
        public string DataTypeValue { get; set; }
        /// <summary>
        /// Write Security Level
        /// </summary>
        [Required]
        public string WriteSecurityLevel { get; set; }
    }

    /// <summary>
    /// Radius Objects
    /// </summary>
    public class ObjectAssociatedPropertiesModels
    {
        /// <summary>
        /// List of Radius Associated Objects
        /// </summary>
        public List<ObjectAssociatedPropertyModel> RadiusObjectAssociatedProperties;

        /// <summary>
        /// Creates new list
        /// </summary>
        public ObjectAssociatedPropertiesModels()
        {
            RadiusObjectAssociatedProperties = new List<ObjectAssociatedPropertyModel>();
        }
    }

    /// <summary>
    /// Radius Associated Object's Properties
    /// </summary>
    public class ObjectAssociatedPropertyModel
    {
        /// <summary>
        /// Object ID associated with the properties
        /// </summary>
        [Required]
        public string ObjectID { get; set; }
        /// <summary>
        /// Display Name
        /// </summary>
        [Required]
        public string DisplayName { get; set; }
        /// <summary>
        /// Object Type ID
        /// </summary>
        [Required]
        public string ObjectTypeID { get; set; }
        /// <summary>
        /// Object Type Text
        /// </summary>
        public string ObjectTypeText { get; set; }
        /// <summary>
        /// Object Type Value
        /// </summary>
        public string ObjectTypeValue { get; set; }
    }
}