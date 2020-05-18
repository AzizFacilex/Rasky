using System.ComponentModel.DataAnnotations.Schema;
namespace Rasky.API.IdentityDb {
    public class UserProfile:IEntity<UserProfile> {
        public UserProfile AddErrors(object obj){
            return this;
        }
        public string Id { get; set; }
        public string Experience { get; set; }
        public string Image { get; set; }
        public string Summary { get; set; }
        public string Rating { get; set; }
        public int Rides { get; set; }
        public bool PrefMusic { get; set; }
        public bool PrefPet { get; set; }
        public bool PrefDiscussion { get; set; }
        public bool PrefSmoke { get; set; }
        public string UserId {get;set;}
        [ForeignKey("UserId")]
        public virtual AppUser User { get; set; }

    }
}