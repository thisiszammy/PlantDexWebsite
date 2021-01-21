using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantDex.Application;
using PlantDex.Application.Common.ContributionSubmissions.Commands;
using PlantDex.Application.Common.Plants.Commands;
using PlantDex.Application.Common.Plants.Queries;
using PlantDex.Application.DTO.PlantsManagement;
using PlantDex.Application.Services;
using PlantDex.Domain.Entities;

namespace PlantDex.Api.Controllers
{
    [Route("api/plants")]
    [ApiController]
    public class PlantDexApiController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ApplicationSecrets applicationSecrets;
        private readonly IPlantClassifierService plantClassifierService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public PlantDexApiController(IMediator mediator,
            ApplicationSecrets applicationSecrets,
            IPlantClassifierService plantClassifierService,
            IWebHostEnvironment webHostEnvironment)
        {
            this.mediator = mediator;
            this.applicationSecrets = applicationSecrets;
            this.plantClassifierService = plantClassifierService;
            this.webHostEnvironment = webHostEnvironment;
        }

        // Plant Management related endpoints
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

        [HttpPut("update/locations")]
        public async Task<IActionResult> UpdatePlantLocations([FromBody] AddPlantLocationsCommand addPlantLocationsCommand)
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
                if (addPlantLocationsCommand == null)
                    return BadRequest(new PlantsManagementResponse
                    {
                        isSuccessful = false,
                        message = "Request body is empty"
                    });

                var taskAddPlantLocation = await mediator.Send(addPlantLocationsCommand);

                if (taskAddPlantLocation.isSuccessful)
                    return Ok(taskAddPlantLocation);
                else
                    return BadRequest(taskAddPlantLocation);
            }

            return BadRequest(new PlantsManagementResponse
            {
                isSuccessful = false,
                message = "An error has occurred"
            });
        }

        [HttpDelete("delete/location")]
        public async Task<IActionResult> DeletePlantLocation(string plantId = "", string lat = "", string lng = "")
        {
            string accessKey = Request.Headers["Authorization"].ToString();

            if (accessKey.Trim().Length < 1 || applicationSecrets.authAccess != accessKey)
                return Unauthorized(new PlantsManagementResponse
                {
                    isSuccessful = false,
                    message = "Invalid Access Key"
                });

            if (plantId.Trim().Length < 1 || lat.Trim().Length < 1 || lng.Trim().Length < 1)
                return BadRequest(new PlantsManagementResponse
                {
                    isSuccessful = false,   
                    message = "Invalid Request Parameters"
                });

            var taskDeleteLocation = await mediator.Send(new DeletePlantLocationCommand
            {
                lat = lat,
                lng = lng,
                plantId = plantId
            });

            if (taskDeleteLocation.isSuccessful)
                return Ok(taskDeleteLocation);
            else
                return BadRequest(taskDeleteLocation);
        }

        [HttpGet("search/name")]
        public async Task<IActionResult> GetPlantsByName(string name = "")
        {
            string accessKey = Request.Headers["Authorization"].ToString();

            if (accessKey.Trim().Length < 1 || applicationSecrets.authAccess != accessKey)
                return Unauthorized(new PlantsManagementResponse
                {
                    isSuccessful = false,
                    message = "Invalid Access Key"
                });


            if (name.Trim().Length < 1)
                return BadRequest(new PlantsManagementResponse
                {
                    isSuccessful = false,
                    message = "Request parameter is empty {commonName}"
                });

            var taskGetPlants = await mediator.Send(new GetPlantByCommonNameQuery()
            {
                CommonName = name
            });

            var taskGetPlants2 = await mediator.Send(new GetPlantByScientificNameQuery()
            {

                ScientificName = name
            });

            PlantsManagementResponse plantsManagementResponse = new PlantsManagementResponse();
            List<string> errors = new List<string>();
            List<Plant> plants = new List<Plant>();

            plantsManagementResponse.isSuccessful = taskGetPlants.isSuccessful && taskGetPlants2.isSuccessful;

            plants.AddRange((taskGetPlants.plants == null) ? new List<Plant>() : taskGetPlants.plants);
            errors.AddRange((taskGetPlants.errors == null) ? new List<string>() : taskGetPlants.errors);

            plants.AddRange((taskGetPlants2.plants == null) ? new List<Plant>() : taskGetPlants2.plants);
            errors.AddRange((taskGetPlants2.errors == null) ? new List<string>() : taskGetPlants2.errors);

            plantsManagementResponse.errors = errors.Distinct().ToList();
            plantsManagementResponse.plants = plants.Distinct().OrderBy(x=>x.ScientificName).ToList();

            plantsManagementResponse.message = "1) " + taskGetPlants.message + " - 2) " + taskGetPlants2.message;

            return Ok(plantsManagementResponse);
        }

        [HttpPost("contribute/submit")]
        public async Task<IActionResult> AddContribution([FromBody] AddContributionSubmissionCommand addContributionSubmissionCommand)
        {
            string accessKey = Request.Headers["Authorization"].ToString();

            if (accessKey.Trim().Length < 1 || applicationSecrets.authAccess != accessKey)
                return Unauthorized(new PlantsManagementResponse
                {
                    isSuccessful = false,
                    message = "Invalid Access Key"
                });

            if(addContributionSubmissionCommand == null)
                return BadRequest(new PlantsManagementResponse
                {
                    isSuccessful = false,
                    message = "Invalid Request Parameters"
                });

            if(addContributionSubmissionCommand.commonName == null || addContributionSubmissionCommand.remarks == null || addContributionSubmissionCommand.scientificName == null || 
                addContributionSubmissionCommand.scientificName == null)
                return BadRequest(new PlantsManagementResponse
                {
                    isSuccessful = false,
                    message = "Invalid Request Parameters"
                });

            var taskAddContribution = await mediator.Send(new AddContributionSubmissionCommand
            {
                commonName = addContributionSubmissionCommand.commonName,
                locations = addContributionSubmissionCommand.locations,
                remarks = addContributionSubmissionCommand.remarks,
                scientificName = addContributionSubmissionCommand.scientificName
            });

            return Ok(taskAddContribution);
        }
        
        [HttpPost("classify/test")]
        public async Task<IActionResult> ClassifyPlant(UploadedImageFile uploadedImageFile)
        {
            string accessKey = Request.Headers["Authorization"].ToString();

            if (accessKey.Trim().Length < 1 || applicationSecrets.authAccess != accessKey)
                return Unauthorized(new PlantsManagementResponse
                {
                    isSuccessful = false,
                    message = "Invalid Access Key"
                });

            if (!ModelState.IsValid)
                return BadRequest(new PlantsManagementResponse() { errors = null, isSuccessful = false, message = "Invalid Parameters", plants = null});

            try
            {
                string destinationPath = Path.Combine(webHostEnvironment.ContentRootPath, "wwwroot\\image_classifier\\que", uploadedImageFile.fileName);
                await System.IO.File.WriteAllBytesAsync(destinationPath, uploadedImageFile.fileData);
                List<string> classificationResults = plantClassifierService.classifyImage(uploadedImageFile.fileName);

                string[] plantResults = classificationResults[0].Split('\n')[1]
                    .Split(',');

                return Ok(new PlantsManagementResponse()
                {
                    isSuccessful = true,
                    errors = new List<string> { classificationResults[1] },
                    message = plantResults[0] + " - " + plantResults[1] + " - " + plantResults[2],
                    plants = null
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new PlantsManagementResponse()
                {
                    isSuccessful = false,
                    errors = new List<string> { ex.Message},
                    message = "Internal Server Error",
                    plants = null
                });
            }
            
            
        }
    }
}
