using PlantDex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlantDex.Domain.Entities
{
    public class PlantLocation : AuditableEntity
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string LocationName { get; set; }
    }
}
