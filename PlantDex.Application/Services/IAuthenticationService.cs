using PlantDex.Api.ViewModel;
using PlantDex.Application.DataTransferObjects.Authentication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlantDex.Application.Services
{
    public interface IAuthenticationService
    {
        public Task<AuthenticationResponse> Register(RegisterViewModel registerViewModel);
        public Task<AuthenticationResponse> Login(LoginViewModel loginViewModel);
    }
}
