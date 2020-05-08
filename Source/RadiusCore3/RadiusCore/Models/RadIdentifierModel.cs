using System;
using System.ComponentModel.DataAnnotations;

namespace RadiusCore.Models
{
    /// <summary>
    /// Identifiers
    /// </summary>
    public class RadIdentifierModel
    {
        [Required]
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public string Value { get; set; }
        public string Category { get; set; }
    }
}
