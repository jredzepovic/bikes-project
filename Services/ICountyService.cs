using System.Collections.Generic;
using bikes_project.Models;

namespace bikes_project.Services
{
    public partial interface ICountyService
    {
        IList<County> GetAllCounties();
    }
}
