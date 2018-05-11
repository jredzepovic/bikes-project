using bikes_project.Models;

namespace bikes_project.Data
{
    public partial interface IUnitOfWork
    {
        IRepository<Role> RoleRepository { get; }
        IRepository<County> CountyRepository { get; }
        IRepository<User> UserRepository { get; }
        IRepository<BikeType> BikeTypeRepository { get; }
        IRepository<BikeCondition> BikeConditionRepository { get; }
        IRepository<BikeAdvertType> BikeAdvertTypeRepository { get; }
        IRepository<Bike> BikeRepository { get; }
        IRepository<AdvertType> AdvertTypeRepository { get; }
        IRepository<AdditionalEquipment> AdditionalEquipmentRepository { get; }
        void Save();
    }
}
