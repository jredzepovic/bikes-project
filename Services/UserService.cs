using System.Collections.Generic;
using System.Linq;
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
            return _unitOfWork.UserRepository.Table.Where(user => user.Email.
                Trim().ToLower().Equals(email.Trim().ToLower())).FirstOrDefault();
        }
    }
}
