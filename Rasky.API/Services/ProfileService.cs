using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Rasky.API.IdentityDb;
using Rasky.API.ViewModels;
namespace Rasky.API.Services {
    public class ProfileService : IProfileService {
        private readonly IRepositoryWrapper repositories;
        private readonly IMapper mapper;

        public ProfileService (IRepositoryWrapper repositories, IMapper mapper) {
            this.repositories = repositories;
            this.mapper = mapper;
        }

        public async Task<PublicProfileViewModel> GetPublicProfile (string email) {
            var mappedUser = new PublicProfileViewModel ();
            var user = await this.repositories.Users.FindById (email);
            mappedUser = this.mapper.Map<AppUser, PublicProfileViewModel> (user, mappedUser);

            var userProfile = await this.repositories.Profiles.FindByCondition (x => x.UserId == user.Id).FirstOrDefaultAsync ();
            if (mappedUser != null && userProfile != null) {
                mappedUser = mapper.Map<UserProfile,PublicProfileViewModel> (userProfile,mappedUser);
                return mappedUser;
            }
            return new PublicProfileViewModel ();

        }
        public async Task CreateProfile (string email) {
            var user = await this.repositories.Users.FindByEmailAsync (email);
            var profile = new UserProfile ();
            profile.UserId = user.Id;
            profile.Image = "https://via.placeholder.com/150";
            profile.PrefDiscussion = false;
            profile.PrefMusic = false;
            profile.PrefPet = false;
            profile.PrefSmoke = false;
            profile.Rides = 0;
            profile.Rating = "10";
            profile.Experience = "Beginner";
            await this.repositories.Profiles.Create (profile);
            await this.repositories.Save ();
        }
    }
}