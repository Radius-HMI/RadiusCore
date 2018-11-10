using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadiusCore.Models
{
    public class RadValueHistoryModel
    {
        /// <summary>
        /// Value ID referenced by the Radius HMI Value
        /// </summary>
        [Required]
        public Guid ValueID { get; set; }
        /// <summary>
        /// Process Value representation - Also known as Tag Name
        /// </summary>
        [Required]
        public Guid PV { get; set; }
        /// <summary>
        /// Signal ID
        /// </summary>
        public string SignalID { get; set; }
        /// <summary>
        /// Value Time Stamp
        /// </summary>
        public string TimeStamp { get; set; }
        /// <summary>
        /// Insert Time Stamp
        /// </summary>
        public string InsertTimeStamp { get; set; }
        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }
    }
}
