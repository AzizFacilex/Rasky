using System.Collections.Generic;
using System.Threading.Tasks;
namespace Rasky.API.IdentityDb{
    public interface IRideRepository:IBaseRepository<Ride>
    {
        Task CreateRangeAsync(List<Ride> rides);
    }
}