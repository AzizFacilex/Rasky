namespace Rasky.API.IdentityDb{
   public class ProfileRepository:BaseRepository<UserProfile>,IProfileRepository{
       public ProfileRepository(AppUserDbContext dbContext):base(dbContext){
       }
   }
}