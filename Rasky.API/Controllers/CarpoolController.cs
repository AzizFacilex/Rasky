using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft;
using System.Threading.Tasks;
using Rasky.API.ViewModels;
using AutoMapper;
using Rasky.API.Services;
namespace Rasky.API.Controllers{
    [Route("api/carpool")]
    [ApiController]

    public class CarpoolController:ControllerBase{
        private readonly IRideService rideService;
        private readonly IMapper mapper;
        public CarpoolController(IRideService rideService, IMapper mapper){
            this.rideService=rideService;
            this.mapper=mapper;

        }
        /// <summary>
        /// Ride creation endpoint
        /// </summary>
        /// <param name="model">View model</param>
        /// <returns>Same model with any messages or errors</returns>
        [HttpPost("create")]
        public async Task<CreateRideViewModel> CreateRide(CreateRideViewModel model)
        {
            return await this.rideService.CreateRide(model);
        }
    }
}