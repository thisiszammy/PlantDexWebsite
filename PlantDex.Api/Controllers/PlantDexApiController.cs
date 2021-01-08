using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public PlantDexApiController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddPlant([FromBody] AddPlantCommand addPlantCommand)
        {

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

      
    }
}
