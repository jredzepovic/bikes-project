using System.Collections.Generic;
using System.Linq;
using bikes_project.Models;
using bikes_project.Data;

namespace bikes_project.Services
{
    public class AdvertTypeService : IAdvertTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdvertTypeService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IList<AdvertType> GetAllAdvertTypes()
        {
            return _unitOfWork.AdvertTypeRepository.Table.ToList();
        }
    }
}
