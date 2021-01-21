using PlantDex.Application.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PlantDex.Api.Services
{
    public class PlantClassifierService : IPlantClassifierService
    {
        public List<string> classifyImage(string filePath)
        {
            ProcessStartInfo classifyImage = new ProcessStartInfo();
            classifyImage.FileName = "python";
            classifyImage.Arguments = string.Format("\"{0}\" \"{1}\"", "C:\\MJ\\WebProjects\\PlantDex\\PlantDex.Api\\wwwroot\\image_classifier\\classify_plant.py", filePath);
            classifyImage.UseShellExecute = false;
            classifyImage.CreateNoWindow = true;
            classifyImage.RedirectStandardOutput = true;
            classifyImage.RedirectStandardError = true; 
            
            using (Process process = Process.Start(classifyImage))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string stderr = process.StandardError.ReadToEnd(); 
                    string result = reader.ReadToEnd();
                    return new List<string>() { result, stderr };
                }
            }
        }
    }
}
