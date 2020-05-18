using System.Threading.Tasks;
using System.Security.Claims;
using System.Linq;
using Newtonsoft.Json;
using Rasky.API.IdentityDb.Helpers.Models;
namespace Rasky.API.IdentityDb.Helpers

{
    public class Tokens
    {
      public static async Task<string> GenerateJwt(ClaimsIdentity identity, IJwtFactory jwtFactory,AppUser us, JwtIssuerOptions jwtOptions, JsonSerializerSettings serializerSettings)
      {
        
        var user = new 
        {
          id = identity.Claims.Single(c => c.Type == "id").Value,
          email=us.Email,
          firstName=us.FirstName,
          lastName=us.LastName,
          token = await jwtFactory.GenerateEncodedToken(us, identity),
          expires_in = (int)jwtOptions.ValidFor.TotalSeconds
        };

        return  JsonConvert.SerializeObject(user);
      }
}
}