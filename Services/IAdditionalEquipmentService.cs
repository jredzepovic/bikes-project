using System;
using bikes_project.ViewModels;
using bikes_project.Models;
using System.IdentityModel.Tokens.Jwt;

namespace bikes_project.Services
{
    public partial interface IAdditionalEquipmentService
    {
        void DeleteAdditionalEquipment(int id);

        AdditionalEquipment GetDetails(int id);

        void Edit(AdditionalEquipmentModel model);
    }
}
