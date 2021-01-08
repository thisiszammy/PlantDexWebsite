using PlantDex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlantDex.Application.DTO.PlantsManagement
{
    public class PlantsManagementResponse
    {
        public string message { get; set; }
        public bool isSuccessful { get; set; }
        public IEnumerable<string> errors { get; set; }
        public IEnumerable<Plant> plants { get; set; }
    }
}
