using PlantDex.Application.DTO.UserManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlantDex.Infrastructure.Persistence
{
    public interface IUserManagementService
    {
        public Task<UserManagementResponse> RegisterAsync(RegisterViewModel registerViewModel);
        public Task<UserManagementResponse> LoginAsync(LoginViewModel loginViewModel);
    }
}
