using System;
using System.Collections.Generic;
using System.Text;

namespace PlantDex.Application
{
    public class ApplicationConstants
    {
        public List<string> accountTypes { get; set; }

        public ApplicationConstants()
        {
            accountTypes = new List<string>()
            {
                "Person",
                "Admin"
            };
        }
    }
}
