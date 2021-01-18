using System;
using System.Collections.Generic;
using System.Text;

namespace PlantDex.Application.DTO.UserManagement
{
    public class UserManagementResponse
    {
        public string Message { get; set; }
        public bool IsSuccessful { get; set; }
        public string _Id { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
