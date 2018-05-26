using System.Collections.Generic;
using bikes_project.Models;

namespace bikes_project.Services
{
    public partial interface IUserService
    {
        User GetUserByEmail(string email);
        User GetUserByID(int id);
    }
}
