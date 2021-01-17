using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantDex.Application;
using PlantDex.Application.DTO.PlantsManagement;
using PlantDex.Application.DTO.RemoteConfiguration;

namespace PlantDex.Api.Controllers
{
    [Route("api/remote-config")]
    [ApiController]
    public class RemoteConfigController : ControllerBase
    {
        private readonly ApplicationConstants applicationConstants;
        private readonly ApplicationSecrets applicationSecrets;

        public RemoteConfigController(ApplicationConstants applicationConstants,
            ApplicationSecrets applicationSecrets)
        {
            this.applicationConstants = applicationConstants;
            this.applicationSecrets = applicationSecrets;
        }

        [HttpGet("version")]
        public IActionResult GetConfig()
        {
            string accessKey = Request.Headers["Authorization"].ToString();

            if (accessKey.Trim().Length < 1 || applicationSecrets.authAccess != accessKey)
                return Unauthorized(new RemoteConfigResponse
                {
                    isSuccessful = false,
                    message = "Invalid Access Key"
                });

            return Ok(new RemoteConfigResponse
            {
                isSuccessful = true,
                message = "Successfully retrieved application configuration",
                version = applicationConstants.version
            });
        }
    }
}
