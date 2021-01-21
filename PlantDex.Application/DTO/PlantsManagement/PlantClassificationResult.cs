using PlantDex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlantDex.Application.DTO.PlantsManagement
{
    public class PlantClassificationResult
    {
        public Plant plant { get; set; }
        public double percentConfidence { get; set; }
    }
}
