using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;
using Rasky.API.IdentityDb;
using Rasky.API.ViewModels;
using Rasky.API.ViewModels.Helpers;
namespace Rasky.API.Services {
    public class AuthService : IAuthService {
        private readonly IRepositoryWrapper repositories;
        private readonly IMapper mapper;
        /// <summary>
        /// Service performing identity operations
        /// </summary>
        /// <param name="repos">Stores</param>
        /// <param name="mapper"></param>
        public AuthService (IRepositoryWrapper repos, IMapper mapper) {
            this.repositories = repos;
            this.mapper = mapper;
        }
        public async Task<RegisterViewModel> Register (RegisterViewModel model) {
            var user = mapper.Map<AppUser> (model);
            var result = await this.repositories.Users.Register (user, user.Password);
            var errors = mapper.Map<List<Message>> (result.Errors.Select (x => new Message (x.Code, x.Description)).ToList ());
            if (!result.Succeeded) model.AddErrors (errors);
            return model;
        }
        public async Task<string> GetConfirmationUrl (RegisterViewModel model, string baseUrl) {
            var user = await this.repositories.Users.FindByEmailAsync (model.emailGroup.FirstOrDefault ().Value);
            return await this.repositories.Users.GetRegisterCallBack (user, baseUrl);
        }
        public async Task<CredentialsViewModel> Login (CredentialsViewModel model) {
            var result = await this.repositories.Users.Authenticate (model.UserName, model.Password);
            var toReturn = new CredentialsViewModel ();
            toReturn.Jwt = result;
            var messages = new List<Message> ();
            if (result == null) {
                messages.Add (new Message ("Login incorrect"));
                toReturn.AddErrors (messages);
                return toReturn;
            };
            if (result != null) {
                messages.Add (new Message ("Login successful", result));
                toReturn.AddMessages (messages);
                return toReturn;
            }
            return null;
        }
        public async Task<RegisterViewModel> IsEmailTaken (string email) {
            var user = await this.repositories.Users.FindByEmailAsync (email);
            if (user == null) return null;
            return new RegisterViewModel { username = user.Email };
        }
        public async Task<Message> ConfirmEmail (string id, string token) {
            var user = await this.repositories.Users.FindById (id);
            if (user == null) return null;
            if (await this.repositories.Users.ConfirmEmail (user, token)) {
                return new Message ("Confirmation", "Successful");
            }
            return new Message ("Confirmation", "Unsuccessful");

        }
    }
}