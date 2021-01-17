using PlantDex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlantDex.Domain.Entities
{
    public class ContributionSubmission : AuditableEntity
    {
        public int Id { get; set; }
        public string ScientificName { get; set; }
        public string CommonName { get; set; }
        public string Remarks { get; set; }
        public string Locations { get; set; }

    }
}
