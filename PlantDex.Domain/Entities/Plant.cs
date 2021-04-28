using PlantDex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlantDex.Domain.Entities
{
    public class Plant : AuditableEntity
    {
        public int Id { get; set; }
        public string CommonName { get; set; }
        public string ScientificName { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Attributes { get; set; }  // stringified JSON Array of PlantAttribute
        public string Locations { get; set; }
        public byte[] PlantImage { get; set; }
        public string _Id { get; set; }
    }
}
