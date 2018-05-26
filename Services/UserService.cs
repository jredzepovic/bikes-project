using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using bikes_project.Models;
using bikes_project.Data;

namespace bikes_project.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public User GetUserByEmail(string email)
        {
            return _unitOfWork.UserRepository.Table.
                Where(user => user.Email.Trim().ToLower().Equals(email.Trim().ToLower())).FirstOrDefault();
        }

        public User GetUserByID(int id)
        {
            return _unitOfWork.UserRepository.Table.
                Include(user => user.IdCountyNavigation).
                Include(user => user.IdRoleNavigation).
                Include(user => user.Bike).
                    Include(user => user.Bike).ThenInclude(bike => bike.AdditionalEquipment).
                    Include(user => user.Bike).ThenInclude(bike => bike.IdCountyNavigation).
                    Include(user => user.Bike).ThenInclude(bike => bike.IdBikeTypeNavigation).
                    Include(user => user.Bike).ThenInclude(bike => bike.IdBikeConditionNavigation).
                        Include(user => user.Bike).ThenInclude(bike => bike.BikeAdvertType).ThenInclude(ad => ad.IdAdvertTypeNavigation).
                Where(user => user.Id == id).FirstOrDefault();
        }
    }
}
