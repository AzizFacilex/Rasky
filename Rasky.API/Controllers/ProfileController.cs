using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Rasky.API.IdentityDb;
using Rasky.API.Services;
using Rasky.API.ViewModels;

namespace Rasky.API.Controllers {
    [Route ("api/profile")]
    [ApiController]
    public class ProfileController : ControllerBase {
        public readonly IProfileService profileService;
        /// <summary>
        /// Controller to perform all user profile related operations
        /// </summary>
        /// <param name="profileService">Service that performs the operations</param>
        public ProfileController (
            IProfileService profileService) {
                this.profileService=profileService;

        }
        /// <summary>
        /// GET the user's public profile
        /// </summary>
        /// <param name="model">User's ID/param>
        /// <returns></returns>
        [HttpGet ("public")]
        public async Task<PublicProfileViewModel> GetPublicProfile (string model) {
            if (!ModelState.IsValid) {
                return new PublicProfileViewModel ();
            }
            
            return await this.profileService.GetPublicProfile(model);
        }
    }

}