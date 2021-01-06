using PlantDex.Api.ViewModel;
using PlantDex.Application.DataTransferObjects.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlantDex.Infrastructure.Persistence;
using PlantDex.Application.Services;

namespace PlantDex.Api.Services
{
    public class UserManagementService : IUserManagementService
    {


        public Task<UserManagementResponse> LoginAsync(LoginViewModel loginViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<UserManagementResponse> RegisterAsync(RegisterViewModel registerViewModel)
        {
            if (registerViewModel == null)
                throw new Exception("Register model is null");


            return null;
        }
    }
}
