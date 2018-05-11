using System.Collections.Generic;
using System.Linq;
using bikes_project.Models;
using bikes_project.Data;

namespace bikes_project.Services
{
    public class CountyService : ICountyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CountyService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IList<County> GetAllCounties()
        {
            return _unitOfWork.CountyRepository.Table.ToList();
        }
    }
}
