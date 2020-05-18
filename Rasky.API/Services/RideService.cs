using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rasky.API.IdentityDb;
using Rasky.API.ViewModels;
namespace Rasky.API.Services {
    public class RideService : IRideService {

        private readonly IRepositoryWrapper repositories;
        private readonly IMapper mapper;

        public RideService (IRepositoryWrapper repositories, IMapper mapper) {
            this.repositories = repositories;
            this.mapper = mapper;
        }

        public async Task<CreateRideViewModel> CreateRide (CreateRideViewModel model) {
            var rides = this.mapper.Map<List<Ride>> (model);
            foreach (Ride r in rides) {
                r.Driver = await this.repositories.Users.FindById (r.DriverId);

            }
            
            await this.repositories.Rides.CreateRangeAsync (rides);
            rides.Select (x => {
                var fromAddress = this.repositories.Addresses.FindByCondition (y => AreEquals (y.Latitude, x.FromAddress.Latitude, 0.0001f) && AreEquals (y.Longitude, x.FromAddress.Longitude, 0.0001f)).FirstOrDefault ();
                var toAddress = this.repositories.Addresses.FindByCondition (y => AreEquals (y.Latitude, x.ToAddress.Latitude, 0.0001f) && AreEquals (y.Longitude, x.ToAddress.Longitude, 0.0001f)).FirstOrDefault ();
                if (fromAddress != null) {
                    this.repositories.Addresses.SetEntityState(x.FromAddress,EntityState.Unchanged);
                }
                if (toAddress != null) {
                    this.repositories.Addresses.SetEntityState(x.ToAddress,EntityState.Unchanged);


                }
                
                return 0;
            }).ToList ();
            
            await this.repositories.Save ();
            return model;
        }
        public bool AreEquals (float a, float b, float tolerance) {
            var diff = Math.Abs (a - b);
            return (diff <= tolerance) ? true : false;
        }
    }
}