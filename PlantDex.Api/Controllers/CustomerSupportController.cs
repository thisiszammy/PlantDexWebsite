using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantDex.Application;
using PlantDex.Application.Common.AppRatings.Commands;
using PlantDex.Application.Common.SubmittedComplaints.Commands;
using PlantDex.Application.DTO.AppRatingManagement;
using PlantDex.Application.DTO.ComplaintsManagement;
using PlantDex.Infrastructure.Persistence;

namespace PlantDex.Api.Controllers
{
    [Route("api/customer-support")]
    [ApiController]
    public class CustomerSupportController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IUserManagementService userManagementService;
        private readonly ApplicationSecrets applicationSecrets;

        public CustomerSupportController(IMediator mediator,
            IUserManagementService userManagementService,
            ApplicationSecrets applicationSecrets)
        {
            this.mediator = mediator;
            this.userManagementService = userManagementService;
            this.applicationSecrets = applicationSecrets;
        }

        [HttpPost("rating/submit")]
        public async Task<IActionResult> PostRating([FromBody] AddAppRatingCommand addAppRatingCommand)
        {

            string accessKey = Request.Headers["Authorization"].ToString();

            if (accessKey.Trim().Length < 1 || applicationSecrets.authAccess != accessKey)
                return Unauthorized(new AppRatingsManagementResponse
                {
                    isSuccessful = false,
                    message = "Invalid Access Key"
                });


            if (ModelState.IsValid)
            {
                if(addAppRatingCommand == null)
                    return BadRequest(new AppRatingsManagementResponse()
                    {
                        isSuccessful = false,
                        message = "Invalid Parameters"
                    });

                if(!(await userManagementService.IsValidUserId(addAppRatingCommand.userId)))
                    return BadRequest(new AppRatingsManagementResponse()
                    {
                        isSuccessful = false,
                        message = "Invalid User ID"
                    });

                var taskAddAppRating = await mediator.Send(addAppRatingCommand);

                return Ok(taskAddAppRating);
            }

            return BadRequest(new AppRatingsManagementResponse()
            {
                isSuccessful = false,
                message = "An error has occurred"
            });
        }

        [HttpPost("complaints/file")]
        public async Task<IActionResult> PostComplaints([FromBody] AddSubmittedComplaintCommand addSubmittedComplaintCommand)
        {
            string accessKey = Request.Headers["Authorization"].ToString();

            if (accessKey.Trim().Length < 1 || applicationSecrets.authAccess != accessKey)
                return Unauthorized(new AppRatingsManagementResponse
                {
                    isSuccessful = false,
                    message = "Invalid Access Key"
                });

            if (ModelState.IsValid)
            {
                if (addSubmittedComplaintCommand == null)
                    return BadRequest(new ComplaintsManagementResponse()
                    {
                        isSuccessful = false,
                        message = "Invalid Parameters"
                    });

                if (!(await userManagementService.IsValidUserId(addSubmittedComplaintCommand.userId)))
                    return BadRequest(new ComplaintsManagementResponse()
                    {
                        isSuccessful = false,
                        message = "Invalid User ID"
                    });

                var taskAddAppRating = await mediator.Send(addSubmittedComplaintCommand);

                return Ok(taskAddAppRating);
            }

            return BadRequest(new ComplaintsManagementResponse()
            {
                isSuccessful = false,
                message = "An error has occurred"
            });

        }
    }
}
