using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
namespace Rasky.API.IdentityDb {
    public class RideRepository : BaseRepository<Ride>, IRideRepository {
        public RideRepository (AppUserDbContext dbContext) : base (dbContext) { }
        public async Task CreateRangeAsync(List<Ride> rides)
        {
            await base.dbContext.Rides.AddRangeAsync(rides);
        }
    }
}