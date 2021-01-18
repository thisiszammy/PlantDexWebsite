using PlantDex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlantDex.Domain.Entities
{
    public class SubmittedAppRating : AuditableEntity
    {
        public int Id { get; set; }
        public string userId { get; set; }
        public int rating { get; set; }
    }
}
