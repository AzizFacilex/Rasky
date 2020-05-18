using System.Threading.Tasks;
namespace Rasky.API.IdentityDb{
    public interface IRepositoryWrapper
    {
        IProfileRepository Profiles{get;}
        IUserRepository Users{get;}
        IRideRepository Rides{get;}
        IAddressRepository Addresses{get;}
        
        Task Save();
    }
}