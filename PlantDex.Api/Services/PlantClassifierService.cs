using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
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
        private readonly IWebHostEnvironment webHostEnvironment;

        public PlantClassifierService(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public List<string> classifyImage(string filePath) {

            try
            {
                var workingDirectory = Path.GetFullPath(webHostEnvironment.ContentRootPath + @"\wwwroot\image_classifier");
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        RedirectStandardInput = true,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        WorkingDirectory = workingDirectory
                    }
                };
                process.Start();

                string[] clCommands = System.IO.File.ReadAllLines(webHostEnvironment.ContentRootPath + @"\wwwroot\image_classifier\cl_commands\commands.txt");
                using (var sw = process.StandardInput)
                {
                    if (sw.BaseStream.CanWrite)
                    {
                        string commandRunPython = "python classify_plant.py " + filePath;
                        foreach(var command in clCommands)
                        {
                            sw.WriteLine(command);
                        }
                        sw.WriteLine(commandRunPython);
                    }
                }
                int ctr = 0;
                string resultsString = string.Empty;
                string responseString = string.Empty;
                while (!process.StandardOutput.EndOfStream)
                {
                    var line = process.StandardOutput.ReadLine();
                    responseString += line + "\n";
                    if (line.Contains("Classification_Result"))
                    {
                        resultsString += line.Split('-')[1];
                    }
                    ctr++;
                }
                string _err = process.StandardError.ReadToEnd();

                string textFile = "Results : \n" 
                    + resultsString + "\n\n Response : \n" 
                    + responseString + "\n\n Errors : \n" + _err;

                System.IO.File.WriteAllText(webHostEnvironment.ContentRootPath + @"\wwwroot\image_classifier\logs\"
                    + DateTime.Now.ToString("yyyyMMddHHmmss") 
                    + ".txt", textFile);

                return new List<string>() { resultsString, responseString, _err };
            }
            catch(Exception ex)
            {
                return new List<string>() { string.Empty, ex.Message, string.Empty };
            }
        }
    }
}
