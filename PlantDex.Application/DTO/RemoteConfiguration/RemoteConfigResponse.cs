using System;
using System.Collections.Generic;
using System.Text;

namespace PlantDex.Application.DTO.RemoteConfiguration
{
    public class RemoteConfigResponse
    {
        public string message { get; set; }
        public bool isSuccessful { get; set; }
        public string version { get; set; }
    }
}
