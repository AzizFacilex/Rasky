using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Rasky.API.IdentityDb{
      public class Address :IEntity<Address> {
        public Address AddErrors (object c) {
            //TODO: Add error here
            return this;
        }
        [NotMapped]
        public string Id{get;set;}
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Governorate { get; set; }
        public string Municipality { get; set; }
        public string StreetName { get; set; }
        public string ExactAddress { get; set; }

        [Key, Column (Order = 0)]
        public float Longitude { get; set; }

        [Key, Column (Order = 1)]
        public float Latitude { get; set; }
    }
}