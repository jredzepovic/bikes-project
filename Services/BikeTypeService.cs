using System.Collections.Generic;
using System.Linq;
using bikes_project.Models;
using bikes_project.Data;

namespace bikes_project.Services
{
    public class BikeTypeService : IBikeTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BikeTypeService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IList<BikeType> GetAllBikeTypes()
        {
            return _unitOfWork.BikeTypeRepository.Table.ToList();
        }
    }
}
