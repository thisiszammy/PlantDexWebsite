using PlantDex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlantDex.Domain.Entities
{
    public class PlantAttribute : AuditableEntity
    {
        public int Id { get; set; }
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
    }
}
