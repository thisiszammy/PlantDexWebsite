using System;
using System.Collections.Generic;
using System.Text;

namespace PlantDex.Application.DTO.PlantsManagement
{
    public class PlantClassificationResult
    {
        public int Id { get; set; }
        public string scientificName { get; set; }
        public string commonName { get; set; }
        public double percentConfidence { get; set; }
    }
}
