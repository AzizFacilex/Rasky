using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Rasky.API.IdentityDb.Helpers;
using Rasky.API.IdentityDb.Helpers.Models;
using Newtonsoft.Json;
namespace Rasky.API.IdentityDb {
    public class UserRepository : BaseRepository<AppUser>, IUserRepository {
        private readonly AppUserDbContext dbContext;

        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly UserManager<AppUser> userManager;
        public UserRepository (AppUserDbContext dbContext,
            IJwtFactory _jwtFactory,
            IOptions<JwtIssuerOptions> _jwtOptions,
            UserManager<AppUser> userManager

        ) : base (dbContext) {
            this.userManager = userManager;
            this._jwtOptions = _jwtOptions.Value;
            this._jwtFactory = _jwtFactory;
        }
        public async Task<AppUser> FindByEmailAsync(string email){
            return await this.userManager.FindByEmailAsync(email);
        }
        public async Task<IdentityResult> Register (AppUser user, string password) {
            return await this.userManager.CreateAsync (user, password);
        }
        public async Task<string> GetRegisterCallBack (AppUser user, string baseUrl) {
            var code = await this.userManager.GenerateEmailConfirmationTokenAsync (user);
            return $"{baseUrl}?userid={user.Id}&code={code}";
        }
        public async Task<string> Authenticate (string username, string password) {
            var identity = await GetClaimsIdentity (username, password);
            if(identity==null) return null;

            var user = await userManager.FindByEmailAsync(username);
            var jwt = await Tokens.GenerateJwt(identity, _jwtFactory, user, _jwtOptions, new JsonSerializerSettings { Formatting = Formatting.Indented });
            return jwt;
        }
        public async Task<bool> ConfirmEmail(AppUser user,string code){
            return (await this.userManager.ConfirmEmailAsync(user,code)).Succeeded;
        }
        private async Task<ClaimsIdentity> GetClaimsIdentity (string userName, string password) {
            if (string.IsNullOrEmpty (userName) || string.IsNullOrEmpty (password))
                return await Task.FromResult<ClaimsIdentity> (null);

            // get the user to verifty
            var userToVerify = await userManager.FindByEmailAsync (userName);

            if (userToVerify == null) return await Task.FromResult<ClaimsIdentity> (null);

            // check the credentials
            if (await userManager.CheckPasswordAsync (userToVerify, password)) {
                return await Task.FromResult (_jwtFactory.GenerateClaimsIdentity (userName, userToVerify.Id));
            }

            // Credentials are invalid, or account doesn't exist
            return await Task.FromResult<ClaimsIdentity> (null);
        }
        public async Task<bool> EmailExists(string email){
            return await this.userManager.FindByEmailAsync(email)==null? false:true;
        }
    }
}