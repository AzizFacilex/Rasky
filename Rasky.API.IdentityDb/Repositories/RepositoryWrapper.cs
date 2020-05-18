using System.Threading.Tasks;
namespace Rasky.API.IdentityDb{
    public class RepositoryWrapper:IRepositoryWrapper{
        private  AppUserDbContext dbContext;
        private IProfileRepository profileRepo;
        private IRideRepository rideRepository;
        private IAddressRepository addressRepository;
        private IUserRepository users;
        public RepositoryWrapper(AppUserDbContext dbContext, IUserRepository users){
            this.dbContext=dbContext;
            this.users=users;
        }
        public IAddressRepository Addresses{
            get{
                if(addressRepository==null){
                    addressRepository=new AddressRepository(dbContext);
                }
                return addressRepository;
            }
        }
        public IRideRepository Rides{
            get {
                if(rideRepository==null){
                    rideRepository=new RideRepository(dbContext);
                }
                return rideRepository;
            }
        }
        public IUserRepository Users{
            get{
                return this.users;
            }
        }
        public IProfileRepository Profiles{
            get {
                if(profileRepo == null)
                {
                    profileRepo = new ProfileRepository(dbContext);
                }
 
                return profileRepo;
            }
        }
        public async Task Save(){
            await this.dbContext.SaveChangesAsync();
        }
    }
}