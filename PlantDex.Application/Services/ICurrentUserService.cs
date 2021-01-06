using System;
using System.Collections.Generic;
using System.Text;

namespace PlantDex.Application.Services
{
    public interface ICurrentUserService
    {
        public string currentUser { get; set; }
    }
}
