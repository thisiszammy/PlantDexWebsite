using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantDex.ContributionManager
{
    public class ContributionSubmission
    {
        public int Id { get; set; }
        public string ScientificName { get; set; }
        public string CommonName { get; set; }
        public string Remarks { get; set; }
        public string Locations { get; set; }
        public byte[] SubmittedImage { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
