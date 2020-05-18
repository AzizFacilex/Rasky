using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Rasky.API.IdentityDb {
    public class Ride : IEntity<Ride> {
        public Ride () {
            this.FromAddress = new Address ();
            this.ToAddress = new Address ();
            this.Passengers = new List<AppUser> ();
        }
        public DateTime CreatedAt { get; set; }
        public string Id { get; set; }
        public string DriverId { get; set; }

        [ForeignKey ("DriverId")]
        public AppUser Driver { get; set; } //from identity
        public List<AppUser> Passengers { get; set; }
        public DateTime Departure { get; set; }
        public int FreeSeats { get; set; }
        public virtual Address FromAddress { get; set; }
        public virtual Address ToAddress { get; set; }
        public float PriceForSeat { get; set; }
        public Ride AddErrors (object c) {
            //TODO: Add error here
            return this;
        }

    }

  
}