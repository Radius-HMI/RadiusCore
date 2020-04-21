using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadiusCore.Models
{
    /// <summary>
    /// Identifiers
    /// </summary>
    public class RadIdentifierModel
    {
        public Guid ID { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
    }
}
