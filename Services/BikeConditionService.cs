using System.Collections.Generic;
using System.Linq;
using bikes_project.Models;
using bikes_project.Data;

namespace bikes_project.Services
{
    public class BikeConditionService : IBikeConditionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BikeConditionService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IList<BikeCondition> GetAllBikeConditions()
        {
            return _unitOfWork.BikeConditionRepository.Table.ToList();
        }
    }
}
