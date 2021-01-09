using Microsoft.AspNetCore.Http;
using PlantDex.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PlantDex.Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public string currentUser { get; set; } 
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            this.currentUser = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
