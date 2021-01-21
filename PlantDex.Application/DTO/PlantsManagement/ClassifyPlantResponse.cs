using System;
using System.Collections.Generic;
using System.Text;

namespace PlantDex.Application.DTO.PlantsManagement
{
    public class ClassifyPlantResponse
    {
        public string message { get; set; }
        public bool isSuccessful { get; set; }
        public IEnumerable<string> errors { get; set; }
        public IEnumerable<PlantClassificationResult> plantClassificationResults { get; set; }
    }

}
