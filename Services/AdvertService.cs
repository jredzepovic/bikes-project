using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using bikes_project.Models;
using bikes_project.Data;
using bikes_project.ViewModels;

namespace bikes_project.Services
{
    public class AdvertService : IAdvertService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public AdvertService(IUnitOfWork unitOfWork,
            IEmailService emailService,
            IConfiguration configuration)
        {
            this._unitOfWork = unitOfWork;
            this._emailService = emailService;
            this._configuration = configuration;
        }

        public void AddAdvert(AddAdvertModel model, User user)
        {
            // this is temporary email, only for demo
            var email = _configuration["Mail:Target"];

            var bike = new Bike()
            {
                Name = model.Name,
                TireSize = model.TireSize,
                Speeds = model.Speeds,
                Weight = model.Weight,
                Color = model.Color,
                PublishDate = DateTime.Now,
                Description = model.Description,
                Image = new byte[0],
                Price = model.Price,
                IdBikeCondition = _unitOfWork.BikeConditionRepository.Table.Where(c => c.Name.Trim().ToLower().Equals(model.Condition.Trim().ToLower())).FirstOrDefault().Id,
                IdBikeType = _unitOfWork.BikeTypeRepository.Table.Where(t => t.Name.Trim().ToLower().Equals(model.Type.Trim().ToLower())).FirstOrDefault().Id,
                IdCounty = _unitOfWork.CountyRepository.Table.Where(c => c.Name.Trim().ToLower().Equals(model.County.Trim().ToLower())).FirstOrDefault().Id,
                IdUser = user.Id
            };
            foreach (var a in model.AdditionalEquipment)
            {
                var add = new AdditionalEquipment()
                {
                    Name = a.Name,
                    Description = a.Description,
                    Amount = a.Amount
                };
                bike.AdditionalEquipment.Add(add);
            }
            _unitOfWork.BikeRepository.Insert(bike);
            foreach (var t in model.AdvertTypes)
            {
                var advertType = new BikeAdvertType()
                {
                    IdBikeNavigation = bike,
                    IdAdvertTypeNavigation = _unitOfWork.AdvertTypeRepository.Table.Where(ty => ty.Name.Trim().ToLower().Equals(t.Name.Trim().ToLower())).FirstOrDefault()
                };
                _unitOfWork.BikeAdvertTypeRepository.Insert(advertType);
            }

            try
            {
                _emailService.SendAdvertAddEmail(email, bike);
            }
            catch (Exception)
            {
                //
            }
            _unitOfWork.Save();
        }

        public Bike GetBikeDetails(int id)
        {
            return _unitOfWork.BikeRepository.Table.
                Include(bike => bike.IdBikeTypeNavigation).
                Include(bike => bike.IdCountyNavigation).
                Include(bike => bike.IdBikeConditionNavigation).
                Include(bike => bike.AdditionalEquipment).
                Include(bike => bike.IdUserNavigation).
                    Include(bike => bike.BikeAdvertType).ThenInclude(type => type.IdAdvertTypeNavigation).
                Where(bike => bike.Id == id).FirstOrDefault();

        }

        public void DeleteBike(int id)
        {
            var b = _unitOfWork.BikeRepository.Table.
                Where(bike => bike.Id == id).FirstOrDefault();

            var additionalEquipment = b.AdditionalEquipment.ToList();
            foreach (var addEq in additionalEquipment)
            {
                _unitOfWork.AdditionalEquipmentRepository.Delete(addEq);
            }

            var bikeAdvertTypes = b.BikeAdvertType.ToList();
            foreach (var bat in bikeAdvertTypes)
            {
                _unitOfWork.BikeAdvertTypeRepository.Delete(bat);
            }

            _unitOfWork.BikeRepository.Delete(b);

            _unitOfWork.Save();
        }

        public void EditAdvert(AddAdvertModel model)
        {
            var b = _unitOfWork.BikeRepository.Table.
                Include(bike => bike.BikeAdvertType).
                Where(bike => bike.Id == model.Id).FirstOrDefault();

            b.Name = model.Name;
            b.TireSize = model.TireSize;
            b.Speeds = model.Speeds;
            b.Weight = model.Weight;
            b.Color = model.Color;
            b.Description = model.Description;
            b.Price = model.Price;
            b.IdBikeCondition = _unitOfWork.BikeConditionRepository.Table.Where(c => c.Name.Trim().ToLower().Equals(model.Condition.Trim().ToLower())).FirstOrDefault().Id;
            b.IdBikeType = _unitOfWork.BikeTypeRepository.Table.Where(t => t.Name.Trim().ToLower().Equals(model.Type.Trim().ToLower())).FirstOrDefault().Id;
            b.IdCounty = _unitOfWork.CountyRepository.Table.Where(c => c.Name.Trim().ToLower().Equals(model.County.Trim().ToLower())).FirstOrDefault().Id;

            foreach (var a in model.AdditionalEquipment)
            {
                var add = new AdditionalEquipment()
                {
                    Name = a.Name,
                    Description = a.Description,
                    Amount = a.Amount
                };
                b.AdditionalEquipment.Add(add);
            }

            foreach (var bat in b.BikeAdvertType.ToList())
            {
                _unitOfWork.BikeAdvertTypeRepository.Delete(bat);
            }

            foreach (var t in model.AdvertTypes)
            {
                var advertType = new BikeAdvertType()
                {
                    IdBikeNavigation = b,
                    IdAdvertTypeNavigation = _unitOfWork.AdvertTypeRepository.Table.Where(ty => ty.Name.Trim().ToLower().Equals(t.Name.Trim().ToLower())).FirstOrDefault()
                };
                _unitOfWork.BikeAdvertTypeRepository.Insert(advertType);
            }

            _unitOfWork.Save();
        }

        public ICollection<Bike> GetAllAdverts()
        {
            return _unitOfWork.BikeRepository.Table.
                Include(bike => bike.IdBikeTypeNavigation).
                Include(bike => bike.IdCountyNavigation).
                Include(bike => bike.IdBikeConditionNavigation).
                Include(bike => bike.AdditionalEquipment).
                Include(bike => bike.IdUserNavigation).
                    Include(bike => bike.BikeAdvertType).ThenInclude(type => type.IdAdvertTypeNavigation)
                .ToList();
        }
    }
}
