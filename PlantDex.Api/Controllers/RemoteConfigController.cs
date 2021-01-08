using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantDex.Application;
using PlantDex.Application.DTO.RemoteConfiguration;

namespace PlantDex.Api.Controllers
{
    [Route("api/remote-config")]
    [ApiController]
    public class RemoteConfigController : ControllerBase
    {
        private readonly ApplicationConstants applicationConstants;

        public RemoteConfigController(ApplicationConstants applicationConstants)
        {
            this.applicationConstants = applicationConstants;
        }

        [HttpGet("/version")]
        public IActionResult GetConfig()
        {
            return Ok(new RemoteConfigResponse
            {
                isSuccessful = true,
                message = "Successfully retrieved application configuration",
                version = applicationConstants.version
            });
        }
    }
}
