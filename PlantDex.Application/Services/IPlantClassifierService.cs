using System;
using System.Collections.Generic;
using System.Text;

namespace PlantDex.Application.Services
{
    public interface IPlantClassifierService
    {
        public List<string> classifyImage(string filePath);
    }
}
