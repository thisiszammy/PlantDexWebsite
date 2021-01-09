using System;
using System.Collections.Generic;
using System.Text;

namespace PlantDex.Application
{
    public class ApplicationConstants
    {
        public List<string> accountTypes { get; set; }

        public string version { get; private set; }

        public ApplicationConstants()
        {
            accountTypes = new List<string>()
            {
                "Person",
                "Admin"
            };

            this.version = "1.0.0";
        }

        
    }
}
