using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantDex.Application;
using PlantDex.Application.Common.Plants.Commands;
using PlantDex.Application.Common.Plants.Queries;
using PlantDex.Application.DTO.PlantsManagement;

namespace PlantDex.Api.Controllers
{
    [Route("api/plants")]
    [ApiController]
    public class PlantDexApiController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ApplicationSecrets applicationSecrets;

        public PlantDexApiController(IMediator mediator,
            ApplicationSecrets applicationSecrets)
        {
            this.mediator = mediator;
            this.applicationSecrets = applicationSecrets;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddPlant([FromBody] AddPlantCommand addPlantCommand)
        {
            string accessKey = Request.Headers["Authorization"].ToString();

            if (accessKey.Trim().Length < 1 || applicationSecrets.authAccess != accessKey)
                return Unauthorized(new PlantsManagementResponse
                {
                    isSuccessful = false,
                    message = "Invalid Access Key"
                });
            

            if (ModelState.IsValid)
            {

                if (addPlantCommand == null)
                    return BadRequest(new PlantsManagementResponse
                    {
                        isSuccessful = false,
                        message = "Request body is empty"
                    });

                var taskAddPlant = await mediator.Send(addPlantCommand);

                return Ok(taskAddPlant);

            }
            return BadRequest(new PlantsManagementResponse
            {
                isSuccessful = false,
                message = "An unknown error has occurred"
            });
        }

        [HttpGet("search/common-name")]
        public async Task<IActionResult> GetPlantsByCommonName(string commonName = "")
        {
            string accessKey = Request.Headers["Authorization"].ToString();

            if (accessKey.Trim().Length < 1 || applicationSecrets.authAccess != accessKey)
                return Unauthorized(new PlantsManagementResponse
                {
                    isSuccessful = false,
                    message = "Invalid Access Key"
                });


            if (commonName.Trim().Length < 1)
                return BadRequest(new PlantsManagementResponse
                {
                    isSuccessful = false,       
                    message = "Request parameter is empty {commonName}"
                });

            var taskGetPlants = await mediator.Send(new GetPlantByCommonNameQuery()
            {
                CommonName = commonName
            });


            return Ok(taskGetPlants);
        }


        [HttpGet("search/scientific-name")]
        public async Task<IActionResult> GetPlantsByScientificName(string scientificName = "")
        {
            string accessKey = Request.Headers["Authorization"].ToString();

            if (accessKey.Trim().Length < 1 || applicationSecrets.authAccess != accessKey)
                return Unauthorized(new PlantsManagementResponse
                {
                    isSuccessful = false,
                    message = "Invalid Access Key"
                });


            if (scientificName.Trim().Length < 1)
                return BadRequest(new PlantsManagementResponse
                {
                    isSuccessful = false,
                    message = "Request parameter is empty {scientificName}"
                });

            var taskGetPlants = await mediator.Send(new GetPlantByScientificNameQuery()
            {
                ScientificName = scientificName
            });

            return Ok(taskGetPlants);
        }

    }
}
