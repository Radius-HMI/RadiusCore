using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RadiusCore.Models
{

    /// <summary>
    /// Signals
    /// </summary>
    public class SignalModels
    {
        /// <summary>
        /// List of Signals
        /// </summary>
        public List<SignalModel> Signals;

        /// <summary>
        /// Creates new list
        /// </summary>
        public SignalModels()
        {
            Signals = new List<SignalModel>();
        }
    }
    /// <summary>
    /// Signal 
    /// </summary>
    public class SignalModel
    {
        /// <summary>
        /// Signal ID
        /// </summary>
        [Required]
        public string SignalID { get; set; }
        /// <summary>
        /// Reference ID. 
        /// Used to reference a group of signals that belong to a group.
        /// An example would be to group a list of signals together that belong to a device.
        /// </summary>
        [Required]
        public string DeviceID { get; set; }
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
        /// Source ID
        /// </summary>
        [Required]
        public string SourceID { get; set; }
        /// <summary>
        /// Source Text
        /// </summary>
        public string SourceText { get; set; }
        /// <summary>
        /// Source Value
        /// </summary>
        public string SourceValue { get; set; }
        /// <summary>
        /// Tag Name
        /// </summary>
        [Required]
        public string TagName { get; set; }
        /// <summary>
        /// Display Name
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// TimeStamp
        /// </summary>
        [Required]
        [DataType(DataType.Time)]
        public string TimeStamp { get; set; }
        /// <summary>
        /// Raw Value
        /// </summary>
        public string RawValue { get; set; }
        /// <summary>
        /// Enabled
        /// </summary>
        [Required]
        public string Enabled { get; set; }
    }

    /// <summary>
    /// SignalViews
    /// </summary>
    public class SignalViewModels
    {
        /// <summary>
        /// List of SignalViews
        /// </summary>
        public List<SignalViewModel> SignalViews;
        ///// <summary>
        ///// Username
        ///// </summary>
        //public string UserName { get; set; }

        /// <summary>
        /// Creates new list
        /// </summary>
        public SignalViewModels()
        {
            SignalViews = new List<SignalViewModel>();
            //UserName = "Anonymous";
        }
    }

    /// <summary>
    /// SignalView 
    /// </summary>
    public class SignalViewModel
    {
        /// <summary>
        /// Creates new list
        /// </summary>
        public SignalViewModel()
        {
            EnumValues = new List<EnumVal>();
        }
        /// <summary>
        /// SignalID
        /// </summary>
        public string SignalID { get; set; }

        /// <summary>
        /// InputSource
        /// </summary>
        public string InputSource { get; set; }
        /// <summary>
        /// OutputSource
        /// </summary>
        public string OutputSource { get; set; }
        /// <summary>
        /// TagName
        /// </summary>
        public string TagName { get; set; }
        /// <summary>
        /// DisplayName
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// ViewDisplayName
        /// </summary>
        public string ViewDisplayName { get; set; }
        /// <summary>
        /// TimeStamp
        /// </summary>
        public string TimeStamp { get; set; }
        /// <summary>
        /// RawValue
        /// </summary>
        public string RawValue { get; set; }
        /// <summary>
        /// Source
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// Enabled
        /// </summary>
        public string Enabled { get; set; }
        /// <summary>
        /// ItemDataType
        /// </summary>
        public string ItemDataType { get; set; }
        /// <summary>
        /// CommChannel
        /// </summary>
        public string CommChannel { get; set; }
        /// <summary>
        /// EnableScaling
        /// </summary>
        public string EnableScaling { get; set; }
        /// <summary>
        /// EU_Min
        /// </summary>
        public string EU_Min { get; set; }
        /// <summary>
        /// EU_Max
        /// </summary>
        public string EU_Max { get; set; }
        /// <summary>
        /// RawMin
        /// </summary>
        public string RawMin { get; set; }
        /// <summary>
        /// RawMax
        /// </summary>
        public string RawMax { get; set; }
        /// <summary>
        /// MinValue
        /// </summary>
        public string MinValue { get; set; }
        /// <summary>
        /// MaxValue
        /// </summary>
        public string MaxValue { get; set; }
        /// <summary>
        /// Precision
        /// </summary>
        public string Precision { get; set; }
        /// <summary>
        /// Quality
        /// </summary>
        public string Quality { get; set; }
        /// <summary>
        /// Units
        /// </summary>
        public string Units { get; set; }
        /// <summary>
        /// WriteSecurityLevel
        /// </summary>
        public string WriteSecurityLevel { get; set; }
        /// <summary>
        /// EnumLookupValue
        /// </summary>
        public string EnumLookupValue { get; set; }
        /// <summary>
        /// EnumValues
        /// </summary>
        public List<EnumVal> EnumValues { get; set; }
    }

    public class EnumVal
    {
        public string Value { get; set; }
        public string Text { get; set; }
        
        public EnumVal(string value, string text)
        {
            Value = value;
            Text = text;
        }
    }

    /// <summary>
    /// SignalView 
    /// </summary>
    public class SignalWriteModel
    {
        /// <summary>
        /// UserName
        /// </summary>
        [Required]
        public string UserName { get; set; }
        /// <summary>
        /// SignalID
        /// </summary>
        [Required]
        public string SignalID { get; set; }
        /// <summary>
        /// RawValue
        /// </summary>
        [Required]
        public string Value { get; set; }
        /// <summary>
        /// Source
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// Comments
        /// </summary>
        public string Comments { get; set; }
    }


    /// <summary>
    /// Signal History
    /// </summary>
    public class SignalHistoryModel
    {
        /// <summary>
        /// Signal History
        /// </summary>
        public List<SignalHistoryPointModel> SignalHistory;

        /// <summary>
        /// Signal History
        /// </summary>
        public SignalHistoryModel()
        {
            SignalHistory = new List<SignalHistoryPointModel>();
        }
    }
    /// <summary>
    /// Signal History Point
    /// </summary>
    public class SignalHistoryPointModel
    {
        /// <summary>
        /// Tag Name
        /// </summary>
        public string TagName { get; set; }
        /// <summary>
        /// Signal ID
        /// </summary>
        public string SignalID { get; set; }
        /// <summary>
        /// Signal Time Stamp
        /// </summary>
        public string SignalTimeStamp { get; set; }
        /// <summary>
        /// Insert Time Stamp
        /// </summary>
        public string InsertTimeStamp { get; set; }
        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }

    }

    public class SignalHistoryRequestModel
    {
        /// <summary>
        /// Select Top
        /// </summary>
        public string SelectTop { get; set; } = string.Empty;
        /// <summary>
        /// Start Date
        /// </summary>
        [DataType(DataType.Time)]
        public string StartDate { get; set; } = string.Empty;
        /// <summary>
        /// End Date
        /// </summary>
        [DataType(DataType.Time)]
        public string EndDate { get; set; } = string.Empty;
        /// <summary>
        /// Tag Name
        /// </summary>
        public string TagName { get; set; } = string.Empty;
        /// <summary>
        /// Signal ID
        /// </summary>
        public string SignalID { get; set; } = string.Empty;
    }

    /// <summary>
    /// Signal Properties
    /// </summary>
    public class SignalPropertiesModels
    {
        /// <summary>
        /// List of Signal Properites
        /// </summary>
        public List<SignalPropertyModels> Signals;

        /// <summary>
        /// Creates new list
        /// </summary>
        public SignalPropertiesModels()
        {
            Signals = new List<SignalPropertyModels>();
        }
    }
    /// <summary>
    /// Signal Property
    /// </summary>
    public class SignalPropertyModels
    {
        /// <summary>
        /// Signal ID
        /// </summary>
        public string SignalPropertyID { get; set; }
        /// <summary>
        /// Signal ID
        /// </summary>
        public string SignalID { get; set; }
        /// <summary>
        /// Data Type ID
        /// </summary>
        [Required]
        public string PropertyName { get; set; }
        /// <summary>
        /// Data Type Text
        /// </summary>
        [Required]
        public string DisplayName { get; set; }
        /// <summary>
        /// Data Type Value
        /// </summary>
        [Required]
        public string PropertyValue { get; set; }
    }
}