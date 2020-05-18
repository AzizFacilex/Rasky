using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
namespace Rasky.API.IdentityDb{
    public interface IUserRepository:IBaseRepository<AppUser>{
        Task<IdentityResult> Register(AppUser user, string password);
        Task<string> GetRegisterCallBack(AppUser user,string baseUrl);
        Task<string> Authenticate(string username,string password);
        Task<bool> EmailExists(string email);
        Task<AppUser> FindByEmailAsync(string email);
        Task<bool> ConfirmEmail(AppUser user,string code);

    }
}