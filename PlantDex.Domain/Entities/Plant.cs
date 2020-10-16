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

        //Attributes will be stringified JSON array of PlantAttribute
        public string Attributes { get; set; }
    }
}
