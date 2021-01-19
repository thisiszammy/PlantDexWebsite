using System;
using System.Collections.Generic;
using System.Text;

namespace PlantDex.Application.Services
{
    public interface IPlantClassifier
    {
        public List<string> classifyImage(string filePath);
    }
}
