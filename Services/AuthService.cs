using System;
using System.Collections.Generic;
using bikes_project.Data;
using bikes_project.Models;
using bikes_project.ViewModels;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace bikes_project.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IConfiguration _configuration;

        public AuthService(IUnitOfWork unitOfWork,
            IConfiguration configuration)
        {
            this._unitOfWork = unitOfWork;
            this._configuration = configuration;
        }

        public void RegisterUser(UserRegisterModel model)
        {
            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Oib = model.Oib,
                Phone = model.Phone,
                CellPhone = model.CellPhone,
                Email = model.Email,
                Address = model.Address,
                Password = GetHashSha256(model.Password),
                IdRole = _unitOfWork.RoleRepository.Table
                                .Where(role => role.Name.Trim().ToLower().Equals("user"))
                                .FirstOrDefault().Id,
                IdCounty = _unitOfWork.CountyRepository.Table
                                .Where(county => county.Name.Trim().ToLower().Equals(model.County.Trim().ToLower()))
                                .FirstOrDefault().Id
            };

            _unitOfWork.UserRepository.Insert(user);
            _unitOfWork.Save();
        }

        public string AuthenticateUser(UserLoginModel model)
        {
            var user = _unitOfWork.UserRepository.Table
                .Where(u => u.Email.Trim().ToLower().Equals(model.Email.Trim().ToLower()))
                .FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            if (!user.Password.Equals(GetHashSha256(model.Password)))
            {
                return null;
            }

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddDays(1),
              signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string GetHashSha256(string text)
        {
            SHA256Managed sha256 = new SHA256Managed();
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));

            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:X2}", x);
            }

            return hashString;
        }
    }
}
