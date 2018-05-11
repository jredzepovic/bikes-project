using System;
using bikes_project.ViewModels;
using System.IdentityModel.Tokens.Jwt;

namespace bikes_project.Services
{
    public partial interface IAuthService
    {
        void RegisterUser(UserRegisterModel model);
        string AuthenticateUser(UserLoginModel model);
    }
}
