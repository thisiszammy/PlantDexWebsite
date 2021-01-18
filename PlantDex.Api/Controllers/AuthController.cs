using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantDex.Api.Models;
using PlantDex.Application.DTO.UserManagement;
using PlantDex.Infrastructure.Persistence;

namespace PlantDex.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserManagementService userManagementService;

        public AuthController(IUserManagementService userManagementService)
        {
            this.userManagementService = userManagementService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await userManagementService.RegisterAsync(registerViewModel);

                if (result.IsSuccessful)
                    return Ok(result);

                return BadRequest(result);
            }
            return BadRequest(new UserManagementResponse()
            {
                IsSuccessful = false,
                Message = "Something went wrong!"
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var taskSignIn = await userManagementService.LoginAsync(loginViewModel);
                if (!taskSignIn.IsSuccessful)
                    return Ok(new UserManagementResponse()
                    {
                        IsSuccessful = false,
                        Message = "Invalid Login"
                    });
                return Ok(new UserManagementResponse()
                {
                    Errors = null,
                    IsSuccessful = true,
                    Message = "Successfull Login",
                    _Id = taskSignIn._Id
                });
            }

            return BadRequest(new UserManagementResponse()
            {
                IsSuccessful = false,
                Message = "Something went wrong!"
            });
        }
    }
}
