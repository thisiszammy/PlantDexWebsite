using PlantDex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlantDex.Domain.Entities
{
    public class SubmittedComplaint : AuditableEntity
    {
        public int Id { get; set; }
        public string userId { get; set; }
        public string appVersion { get; set; }
        public string phoneVersion { get; set; }
        public string remarks { get; set; }

    }
}
