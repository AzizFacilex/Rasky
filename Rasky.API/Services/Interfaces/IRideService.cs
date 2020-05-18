using System.Threading.Tasks;
using Rasky.API.IdentityDb;
using Rasky.API.ViewModels;
namespace Rasky.API.Services{
    public interface IRideService{
        Task<CreateRideViewModel> CreateRide(CreateRideViewModel rid);
    }
}