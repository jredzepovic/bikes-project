using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using bikes_project.Models;
using bikes_project.ViewModels;
using bikes_project.Data;

namespace bikes_project.Services
{
    public class AdditionalEquipmentService : IAdditionalEquipmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdditionalEquipmentService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public AdditionalEquipment GetDetails(int id)
        {
            var addEq = _unitOfWork.AdditionalEquipmentRepository.Table.
                Include(a => a.IdBikeNavigation).
                    Include(a => a.IdBikeNavigation).ThenInclude(b => b.IdUserNavigation).
                Where(a => a.Id == id).FirstOrDefault();

            return addEq;
        }

        public void DeleteAdditionalEquipment(int id)
        {
            var addEq = _unitOfWork.AdditionalEquipmentRepository.Table.
                Where(a => a.Id == id).FirstOrDefault();
            _unitOfWork.AdditionalEquipmentRepository.Delete(addEq);

            _unitOfWork.Save();
        }

        public void Edit(AdditionalEquipmentModel model)
        {
            var eq = _unitOfWork.AdditionalEquipmentRepository.Table.Where(e => e.Id == model.Id).FirstOrDefault();

            eq.Name = model.Name;
            eq.Description = model.Description;
            eq.Amount = model.Amount;

            _unitOfWork.Save();
        }
    }
}
