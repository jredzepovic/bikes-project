using System;
using System.Collections.Generic;
using bikes_project.ViewModels;
using bikes_project.Models;
using System.IdentityModel.Tokens.Jwt;

namespace bikes_project.Services
{
    public partial interface IAdvertService
    {
        void AddAdvert(AddAdvertModel model, User user);

        Bike GetBikeDetails(int id);

        void DeleteBike(int id);

        void EditAdvert(AddAdvertModel model);

        ICollection<Bike> GetAllAdverts();
    }
}
