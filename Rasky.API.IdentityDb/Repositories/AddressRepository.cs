namespace Rasky.API.IdentityDb{
   public class AddressRepository:BaseRepository<Address>,IAddressRepository{
       public AddressRepository(AppUserDbContext dbContext):base(dbContext){
       }
   }
}