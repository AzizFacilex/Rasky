using System.Threading.Tasks;
using Rasky.API.ViewModels;
using Rasky.API.ViewModels.Helpers;
namespace Rasky.API.Services {
    public interface IAuthService {
        Task<RegisterViewModel> Register (RegisterViewModel model);
        Task<CredentialsViewModel> Login (CredentialsViewModel model);
        Task<string> GetConfirmationUrl (RegisterViewModel email, string baseUrl);
        Task<RegisterViewModel> IsEmailTaken (string email);
        Task<Message> ConfirmEmail (string id, string token);
    }
}