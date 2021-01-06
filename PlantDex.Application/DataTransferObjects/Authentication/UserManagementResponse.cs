using System;
using System.Collections.Generic;
using System.Text;

namespace PlantDex.Application.DataTransferObjects.Authentication
{
    public class UserManagementResponse
    {
        public string Message { get; set; }
        public bool IsSuccessful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
