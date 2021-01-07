using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlantDex.Infrastructure.Persistence;
using PlantDex.Application.Services;
using PlantDex.Application.DTO.UserManagement;
using Microsoft.AspNetCore.Identity;
using PlantDex.Application;

namespace PlantDex.Api.Services
{
    public class UserManagementService : IUserManagementService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationConstants applicationConstants;

        public UserManagementService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationConstants applicationConstants)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.applicationConstants = applicationConstants;
        }

        public Task<UserManagementResponse> LoginAsync(LoginViewModel loginViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task<UserManagementResponse> RegisterAsync(RegisterViewModel registerViewModel)
        {


            if (registerViewModel == null)
                throw new Exception("Register model is null");

            if (registerViewModel.Password != registerViewModel.ConfirmPassword)
                throw new Exception("Passwords not matching");

            if (!applicationConstants.accountTypes.Contains(registerViewModel.AccountType))
                throw new Exception("Invalid account type");


            ApplicationUser applicationUser = new ApplicationUser()
            {
                FirstName = registerViewModel.FirstName,
                MiddleName = registerViewModel.MiddleName,
                LastName = registerViewModel.LastName,
                Email = registerViewModel.Email,
                PhoneNumber = registerViewModel.PhoneNumber,
                UserName = registerViewModel.Username
            };

            IdentityRole role = new IdentityRole()
            {
                Name = registerViewModel.AccountType
            };

            bool isExistingRole = await roleManager.RoleExistsAsync(registerViewModel.AccountType);

            if (!isExistingRole)
            {
                var taskCreateRole = await roleManager.CreateAsync(role);

                if (!taskCreateRole.Succeeded)
                {
                    return new UserManagementResponse()
                    {
                        Errors = taskCreateRole.Errors.Select(x => x.Description),
                        IsSuccessful = false,
                        Message = "An error has occurred"
                    };
                }
            }


            var taskCreateUser = await userManager.CreateAsync(applicationUser, registerViewModel.Password);

            if (!taskCreateUser.Succeeded)
            {
                return new UserManagementResponse()
                {
                    Errors = taskCreateUser.Errors.Select(x => x.Description),
                    IsSuccessful = false,
                    Message = "An error has occurred"
                };
            }

            var taskAssignRole = await userManager.AddToRoleAsync(applicationUser, role.Name);

            return new UserManagementResponse()
            {
                Errors = null,
                IsSuccessful = true,
                Message = "User successfully registered"
            };

        }
    }
}
