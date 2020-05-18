using Rasky.API.IdentityDb;
using System.Threading.Tasks;
using Rasky.API.ViewModels;
namespace Rasky.API.Services {
    public interface IProfileService
    {
         Task<PublicProfileViewModel> GetPublicProfile(string userId);
         Task CreateProfile(string userId);
    }
}