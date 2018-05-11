using System;
using Microsoft.Extensions.Logging;
using bikes_project.Models;

namespace bikes_project.Data
{
    public partial class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DatabaseContext _context;
        private readonly ILogger _logger;

        private IRepository<Role> _roleRepository;
        private IRepository<County> _countyRepository;
        private IRepository<User> _userRepository;
        private IRepository<BikeType> _bikeTypeRepository;
        private IRepository<BikeCondition> _bikeConditionRepository;
        private IRepository<BikeAdvertType> _bikeAdvertTypeRepository;
        private IRepository<Bike> _bikeRepository;
        private IRepository<AdvertType> _advertTypeRepository;
        private IRepository<AdditionalEquipment> _additionalEquipmentRepository;

        public UnitOfWork(DatabaseContext context, ILogger<UnitOfWork> logger)
        {
            this._context = context;
            this._logger = logger;
        }

        public IRepository<Role> RoleRepository
        {
            get
            {
                if (this._roleRepository == null)
                {
                    this._roleRepository = new Repository<Role>(_context, _logger);
                }
                return _roleRepository;
            }
        }

        public IRepository<County> CountyRepository
        {
            get
            {
                if (this._countyRepository == null)
                {
                    this._countyRepository = new Repository<County>(_context, _logger);
                }
                return _countyRepository;
            }
        }

        public IRepository<User> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                {
                    this._userRepository = new Repository<User>(_context, _logger);
                }
                return _userRepository;
            }
        }

        public IRepository<BikeType> BikeTypeRepository
        {
            get
            {
                if (this._bikeTypeRepository == null)
                {
                    this._bikeTypeRepository = new Repository<BikeType>(_context, _logger);
                }
                return _bikeTypeRepository;
            }
        }

        public IRepository<BikeCondition> BikeConditionRepository
        {
            get
            {
                if (this._bikeConditionRepository == null)
                {
                    this._bikeConditionRepository = new Repository<BikeCondition>(_context, _logger);
                }
                return _bikeConditionRepository;
            }
        }

        public IRepository<BikeAdvertType> BikeAdvertTypeRepository
        {
            get
            {
                if (this._bikeAdvertTypeRepository == null)
                {
                    this._bikeAdvertTypeRepository = new Repository<BikeAdvertType>(_context, _logger);
                }
                return _bikeAdvertTypeRepository;
            }
        }

        public IRepository<Bike> BikeRepository
        {
            get
            {
                if (this._bikeRepository == null)
                {
                    this._bikeRepository = new Repository<Bike>(_context, _logger);
                }
                return _bikeRepository;
            }
        }

        public IRepository<AdvertType> AdvertTypeRepository
        {
            get
            {
                if (this._advertTypeRepository == null)
                {
                    this._advertTypeRepository = new Repository<AdvertType>(_context, _logger);
                }
                return _advertTypeRepository;
            }
        }

        public IRepository<AdditionalEquipment> AdditionalEquipmentRepository
        {
            get
            {
                if (this._additionalEquipmentRepository == null)
                {
                    this._additionalEquipmentRepository = new Repository<AdditionalEquipment>(_context, _logger);
                }
                return _additionalEquipmentRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
