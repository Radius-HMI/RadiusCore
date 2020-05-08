using System;
using System.ComponentModel.DataAnnotations;

namespace RadiusCore.Models
{
    public class RadValueHistoryModel
    {

        [Required]
        public string ID { get; set; } = Guid.NewGuid().ToString();
        /// <summary>
        /// Value ID referenced by the Radius HMI Value
        /// </summary>
        [Required]
        public string ValueID { get; set; }
        /// <summary>
        /// Process Value representation - Also known as Tag Name
        /// </summary>
        [Required]
        public string PV { get; set; }
        /// <summary>
        /// Signal ID
        /// </summary>
        [Required]
        public string SignalID { get; set; }
        /// <summary>
        /// Value Time Stamp
        /// </summary>
        public string TimeStamp { get; set; }
        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }
    }
}
