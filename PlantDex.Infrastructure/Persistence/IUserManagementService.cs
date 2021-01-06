using PlantDex.Api.ViewModel;
using PlantDex.Application.DataTransferObjects.Authentication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlantDex.Application.Services
{
    public interface IUserManagementService
    {
        public Task<UserManagementResponse> RegisterAsync(RegisterViewModel registerViewModel);
        public Task<UserManagementResponse> LoginAsync(LoginViewModel loginViewModel);
    }
}
